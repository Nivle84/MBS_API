using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBS_API;
using MBStest01.Models;
using Newtonsoft.Json;
using System.Net.Http;
using SplashScreenTest02.Models;
using System.Collections.ObjectModel;

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

        [HttpGet("withdata/{id}")]
        public async Task<ActionResult> GetDaysWithData(int id)
		{
            var days = await _context.Days
                //.Include(u => u.User)
                .Include(m => m.Mood)
                .Include(i => i.Influence)
				.Include(n => n.Note)
                .Where(u => u.UserID == id)
				.ToListAsync();

            if (days.Count > 0)
                return Ok(days);
			else
                return NotFound();
        }

        [HttpGet("usergraphdays/{userid}")]
        public async Task<ActionResult> GetUserGraphDays(int userid)
		{
            var days = await _context.Days
                .Where(u => u.UserID == userid)
                .OrderByDescending(d => d.Date)
                .ToListAsync();

			//ObservableCollection<GraphDay> graphDays = new ObservableCollection<GraphDay>();
            List<GraphDay> graphDays = new List<GraphDay>();

			//Task stripDaysTask = Task.Run(async () => graphDays = await StripDays(days));
			if (days.Count >= 30)
			{
				for (int i = 0; i < 30; i++)
				{
					graphDays.Add(
						new GraphDay
						{
							MoodID = days[i].MoodID,
							InfluenceID = days[i].InfluenceID,
							Date = days[i].Date
						});
				}
			}
			else if (days.Count >= 7)
			{
				for (int i = 0; i < 7; i++)
				{
					graphDays.Add(
						new GraphDay
						{
							MoodID = days[i].MoodID,
							InfluenceID = days[i].InfluenceID,
							Date = days[i].Date
						});
				}
			}

            graphDays.OrderBy(d => d.Date).ToList();

			if (graphDays.Count > 0)
                return Ok(graphDays);
            else
                return NotFound();
		}

  //      public async Task<List<GraphDay>> StripDays(List<Day> days)
		//{
  //          List<GraphDay> graphDays = new List<GraphDay>();

  //          if (days.Count >= 30)
  //          {
  //              for (int i = 0; i < 30; i++)
  //              {
  //                  graphDays.Add(
  //                      new GraphDay
  //                      {
  //                          MoodID = days[i].MoodID,
  //                          InfluenceID = days[i].InfluenceID,
  //                          Date = days[i].Date
  //                      });
  //              }
  //          }
  //          else if (days.Count >= 7)
  //          {
  //              for (int i = 0; i < 7; i++)
  //              {
  //                  graphDays.Add(
  //                      new GraphDay
  //                      {
  //                          MoodID = days[i].MoodID,
  //                          InfluenceID = days[i].InfluenceID,
  //                          Date = days[i].Date
  //                      });
  //              }
  //          }

  //          return graphDays;
  //      }


        //[HttpGet("byuseridwithdata")]

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
            _context.Entry(day.Note).State = EntityState.Modified;

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
        public async Task<ActionResult<Day>> PostDay(Day receivedDay)
        {
            //Day dayToPost = new Day();
            //dayToPost.Date = day.Date;
            //dayToPost.UserID = day.User.UserID;
            //dayToPost.MoodID = day.Mood.MoodID;
            //dayToPost.InfluenceID = day.Influence.InfluenceID;
            //if (day.Note != null)
            //    dayToPost.HasNote = true;
            //dayToPost.Note = day.Note;
   //         if (receivedDay.DayID != 0)
			//{
   //             var day = (Day) await _context.Days.FirstOrDefaultAsync(d => d.DayID == receivedDay.DayID);
   //             day.MoodID = receivedDay.MoodID;
   //             day.InfluenceID = receivedDay.InfluenceID;
   //             //day.
			//}


            _context.Days.Add(receivedDay);
            await _context.SaveChangesAsync();

			return CreatedAtAction("GetDay", new { id = receivedDay.DayID }, receivedDay);
			//return Ok();
        }

        [HttpPost("postmultiple")]
        public async Task<ActionResult<List<Day>>> PostDayList(List<Day> receivedDayList)
		{
            _context.AddRange(receivedDayList);
            await _context.SaveChangesAsync();

            return Ok();
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
