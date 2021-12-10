﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBS_API;
using MBStest01.Models;

namespace MBSAPITest01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly MBSContext _context;

        public DaysController(MBSContext context)
        {
            _context = context;
        }

        // GET: api/Days
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDays()
        {
            return await _context.Days.ToListAsync();
        }

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var day = await _context.Days.FindAsync(id);

            if (day == null)
            {
                return NotFound();
            }

            return day;
        }

        [HttpGet("withdata")]
        public async Task<ActionResult> GetUsersDaysWithData(int id)
		{
            var day = await _context.Days
                .Include(i => i.Influence)
                .Include(m => m.Mood)
                .Include(n => n.Note)
                .Include(u => u.User)
                .ToListAsync();
                //.FirstOrDefaultAsync(d => d.User.UserID == id);
                //.ThenInclude(d => d.)
                //.FirstOrDefaultAsync(d => d.DayID == id);

            return Ok(day);
		}

        // PUT: api/Days/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDay(int id, Day day)
        {
            if (id != day.DayID)
            {
                return BadRequest();
            }

            _context.Entry(day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Days
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Day>> PostDay(Day day)
        {
            _context.Days.Add(day);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDay", new { id = day.DayID }, day);
        }

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            var day = await _context.Days.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }

            _context.Days.Remove(day);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayExists(int id)
        {
            return _context.Days.Any(e => e.DayID == id);
        }
    }
}
