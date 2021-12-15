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
    public class UsersController : ControllerBase
    {
        private readonly MBSContext _context;

        public UsersController(MBSContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
                //.Include(i => i.Notes)
                //.Where(u => u.UserID == id)
                //.FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

  //      [HttpGet("{id}/days")]
  //      public async Task<ActionResult<IEnumerable<Day>>> GetUsersDays(int id)
		//{
  //          var daysList = await _context.Days.Where(d => d.User.UserID == id).ToListAsync();

  //          return Ok(daysList);
		//}

		//[HttpGet("{id}/withnotes")]
		//public async Task<ActionResult<User>> GetUserWithNotes(int id)
		//{
		//          //Dette går ikke da de to objekter henviser til hinanden ad infinitum... -_-
		//          var user = await _context.Users.FindAsync(id);
		//          var notesList = await _context.Notes
		//              .Where(u => u.UserID == id)
		//              .ToListAsync();
		//          user.Notes = notesList;

		//          return Ok(user);
		//}

		[HttpGet("{id}/days")]
		public async Task<ActionResult<Day>> GetDaysByUserID(int id)
		{
			var days = await _context.Days
				.Include(i => i.Influence)
				//.Where(user => user.User.UserID == id)
				.Include(m => m.Mood)
				.Include(n => n.Note)
				.Where(u => u.User.UserID == id)
				//.Include(u => u.User)
				.ToListAsync();

			return Ok(days);
		}


		// PUT: api/Users/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
