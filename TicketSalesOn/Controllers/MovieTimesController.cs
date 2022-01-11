#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSalesOn.Models;

namespace TicketSalesOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTimesController : ControllerBase
    {
        private readonly TicketSalesContext _context;

        public MovieTimesController(TicketSalesContext context)
        {
            _context = context;
        }

        // GET: api/MovieTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieTimes>>> GetMoviesTimes()
        {
            return await _context.MoviesTimes.ToListAsync();
        }

        // GET: api/MovieTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieTimes>> GetMovieTimes(int id)
        {
            var movieTimes = await _context.MoviesTimes.FindAsync(id);

            if (movieTimes == null)
            {
                return NotFound();
            }

            return movieTimes;
        }

        // PUT: api/MovieTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieTimes(int id, MovieTimes movieTimes)
        {
            if (id != movieTimes.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieTimes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieTimesExists(id))
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

        // POST: api/MovieTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieTimes>> PostMovieTimes(MovieTimes movieTimes)
        {
            _context.MoviesTimes.Add(movieTimes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieTimes", new { id = movieTimes.Id }, movieTimes);
        }

        // DELETE: api/MovieTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieTimes(int id)
        {
            var movieTimes = await _context.MoviesTimes.FindAsync(id);
            if (movieTimes == null)
            {
                return NotFound();
            }

            _context.MoviesTimes.Remove(movieTimes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieTimesExists(int id)
        {
            return _context.MoviesTimes.Any(e => e.Id == id);
        }
    }
}
