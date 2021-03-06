using System;
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
    public class MoodsController : ControllerBase
    {
        private readonly MBSContext _context;

        public MoodsController(MBSContext context)
        {
            _context = context;
        }

        // GET: api/Moods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mood>>> GetMoods()
        {
            return await _context.Moods.ToListAsync();
        }

        // GET: api/Moods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mood>> GetMood(int id)
        {
            var mood = await _context.Moods.FindAsync(id);

            if (mood == null)
            {
                return NotFound();
            }

            return mood;
        }

        // PUT: api/Moods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMood(int id, Mood mood)
        {
            if (id != mood.MoodID)
            {
                return BadRequest();
            }

            _context.Entry(mood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoodExists(id))
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

        // POST: api/Moods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mood>> PostMood(Mood mood)
        {
            _context.Moods.Add(mood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMood", new { id = mood.MoodID }, mood);
        }
        [HttpPost("multiple")]
        public async Task<ActionResult<Mood>> PostMood(List<Mood> moods)
        {
            _context.Moods.AddRange(moods);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Moods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMood(int id)
        {
            var mood = await _context.Moods.FindAsync(id);
            if (mood == null)
            {
                return NotFound();
            }

            _context.Moods.Remove(mood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoodExists(int id)
        {
            return _context.Moods.Any(e => e.MoodID == id);
        }
    }
}
