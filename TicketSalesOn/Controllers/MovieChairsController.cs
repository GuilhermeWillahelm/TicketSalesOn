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
    public class MovieChairsController : ControllerBase
    {
        private readonly TicketSalesContext _context;

        public MovieChairsController(TicketSalesContext context)
        {
            _context = context;
        }

        // GET: api/MovieChairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieChair>>> GetMovieChairs()
        {
            return await _context.MovieChairs.ToListAsync();
        }

        // GET: api/MovieChairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieChair>> GetMovieChair(int id)
        {
            var movieChair = await _context.MovieChairs.FindAsync(id);

            if (movieChair == null)
            {
                return NotFound();
            }

            return movieChair;
        }

        // PUT: api/MovieChairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieChair(int id, MovieChair movieChair)
        {
            if (id != movieChair.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieChair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieChairExists(id))
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

        // POST: api/MovieChairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieChair>> PostMovieChair(MovieChair movieChair)
        {
            _context.MovieChairs.Add(movieChair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieChair", new { id = movieChair.Id }, movieChair);
        }

        // DELETE: api/MovieChairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieChair(int id)
        {
            var movieChair = await _context.MovieChairs.FindAsync(id);
            if (movieChair == null)
            {
                return NotFound();
            }

            _context.MovieChairs.Remove(movieChair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieChairExists(int id)
        {
            return _context.MovieChairs.Any(e => e.Id == id);
        }
    }
}
