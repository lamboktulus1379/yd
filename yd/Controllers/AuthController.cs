using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using yd.Models;

namespace yd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly GraContext _context;
        private readonly JWTSettings _jwtsettings;

        public AuthController(GraContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] User user)
        {
            user = await _context.Users
                .Where(u => u.EmailAddress == user.EmailAddress || u.UserName == u.EmailAddress && u.Password == user.Password).FirstOrDefaultAsync();

            UserWithToken userWithToken = new UserWithToken(user);

            user.Password = null;

            if (userWithToken == null)
            {
                return NotFound();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.EmailAddress)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }
        [Authorize]
        [HttpGet("User")]
        public async Task<ActionResult<UserDTO>> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var emailAddress = claim[0].Value;
            var user = await _context.Users
                .Where(u => u.EmailAddress == emailAddress).FirstAsync();

            if (user == null)
            {
                return NotFound();
            }
            return UserToDTO(user);
        }

        public static UserDTO UserToDTO(User user) =>
            new UserDTO
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                UserName = user.UserName
            };
    }
}
