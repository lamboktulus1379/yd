using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yd.Migrations;
using yd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YDsController : ControllerBase
    {
        private readonly YDContext _context;
        public YDsController(YDContext context)
        {
            _context = context;
        }
        // GET: api/<YDsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YD>>>  Get()
        {
            return  await _context.YD.ToListAsync();
        }

        // GET api/<YDsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YD>> Get(int id)
        {
            var yd = await _context.YD.FindAsync(id);

            if (yd == null)
            {
                return NotFound();
            }
            return yd;
        }

        // POST api/<YDsController>
        [HttpPost]
        public async Task<ActionResult<YD>> Post(YD yd)
        {
            _context.YD.Add(yd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = yd.Id }, yd);
        }

        // PUT api/<YDsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, YD yd)
        {
            if (id != yd.Id)
            {
                return BadRequest();
            }

            _context.Entry(yd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(yd);
        }

        // DELETE api/<YDsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YD>> Delete(int id)
        {
            var yd = await _context.YD.FindAsync(id);
            if (yd == null)
            {
                return NotFound();
            }
            _context.YD.Remove(yd);
            await _context.SaveChangesAsync();

            return yd;
        }
    }
}
