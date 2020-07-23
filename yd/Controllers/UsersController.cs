using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using yd.Models;

namespace yd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly GraContext _context;

        public UsersController(GraContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
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

        public class FIleUploadAPI
        {
            public IFormFile files { get; set; }
        }
        [HttpPost("UploadFile")]
        public async Task<string> Post(FIleUploadAPI files)
        {
            if (files.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + files.files.FileName))
                    {
                        files.files.CopyTo(filestream);
                        filestream.Flush();
                        return "\\uploads\\" + files.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }

        [HttpPost("picture")]
        public ActionResult<Picture> Picture(IFormFile file)
        {
            try
            {
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);

                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);

                return Ok(new { length = file.Length, name = file.FileName });
            }
            catch (Exception)
            {
                return BadRequest();
            }


           /* if (image.Length> 0)
            {
                var filePath = Path.Combine("wwwroot/uploads", image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return Ok(new { status = true, message = "Picture Posted Successfully" });*/
        }




    }
}
