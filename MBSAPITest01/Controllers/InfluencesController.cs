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
    public class InfluencesController : ControllerBase
    {
        private readonly MBSContext _context;

        public InfluencesController(MBSContext context)
        {
            _context = context;
        }

        // GET: api/Influences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Influence>>> GetInfluences()
        {
            return await _context.Influences.ToListAsync();
        }

        // GET: api/Influences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Influence>> GetInfluence(int id)
        {
            var influence = await _context.Influences.FindAsync(id);

            if (influence == null)
            {
                return NotFound();
            }

            return influence;
        }

        // PUT: api/Influences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfluence(int id, Influence influence)
        {
            if (id != influence.InfluenceID)
            {
                return BadRequest();
            }

            _context.Entry(influence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfluenceExists(id))
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

        // POST: api/Influences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Influence>> PostInfluence(Influence influence)
        {
            _context.Influences.Add(influence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfluence", new { id = influence.InfluenceID }, influence);
        }

        // DELETE: api/Influences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfluence(int id)
        {
            var influence = await _context.Influences.FindAsync(id);
            if (influence == null)
            {
                return NotFound();
            }

            _context.Influences.Remove(influence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfluenceExists(int id)
        {
            return _context.Influences.Any(e => e.InfluenceID == id);
        }
    }
}
