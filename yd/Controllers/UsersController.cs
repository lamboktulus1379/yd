using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using yd.Models;

namespace yd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly YDContext _context;

        public UsersController(YDContext context)
        {
            _context = context;
        }
       

        [HttpGet]
        public async Task<ActionResult<User>> GetUser()
        {
           
            string emailAddress = HttpContext.User.Identity.Name;
            var user = await _context.Users
                .Where(user => user.EmailAddress == emailAddress).FirstOrDefaultAsync();

            user.Password = null;

            if (user == null)
            {
                return user;
            }

            return user;
        }

        // GET api/<YDsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
