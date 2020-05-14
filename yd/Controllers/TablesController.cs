using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yd.Models;

namespace yd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly YDContext _context;
        public TablesController(YDContext context)
        {
            _context = context;
        }


        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            var room = await _context.Rooms.Include(room => room.Tables).Where(room => room.Id == id).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<ActionResult<Table>> Post(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = table.Id }, table);
        }

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Table table)
        {
            if (id != table.Id)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(table);
        }

    }
}
