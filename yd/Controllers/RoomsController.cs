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
    public class RoomsController : ControllerBase
    {
        private readonly YDContext _context;
        public RoomsController(YDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> Get()
        {
            return await _context.Rooms.Include(room => room.Tables).ToListAsync();
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
        public async Task<ActionResult<Room>> Post(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = room.Id }, room);
        }

    }
}
