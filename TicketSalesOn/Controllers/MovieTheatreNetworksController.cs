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
    public class MovieTheatreNetworksController : ControllerBase
    {
        private readonly TicketSalesContext _context;

        public MovieTheatreNetworksController(TicketSalesContext context)
        {
            _context = context;
        }

        // GET: api/MovieTheatreNetworks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieTheatreNetwork>>> GetMovieTheatres()
        {
            return await _context.MovieTheatres.ToListAsync();
        }

        // GET: api/MovieTheatreNetworks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieTheatreNetwork>> GetMovieTheatreNetwork(int id)
        {
            var movieTheatreNetwork = await _context.MovieTheatres.FindAsync(id);

            if (movieTheatreNetwork == null)
            {
                return NotFound();
            }

            return movieTheatreNetwork;
        }

        // PUT: api/MovieTheatreNetworks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieTheatreNetwork(int id, MovieTheatreNetwork movieTheatreNetwork)
        {
            if (id != movieTheatreNetwork.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieTheatreNetwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieTheatreNetworkExists(id))
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

        // POST: api/MovieTheatreNetworks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieTheatreNetwork>> PostMovieTheatreNetwork(MovieTheatreNetwork movieTheatreNetwork)
        {
            _context.MovieTheatres.Add(movieTheatreNetwork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieTheatreNetwork", new { id = movieTheatreNetwork.Id }, movieTheatreNetwork);
        }

        // DELETE: api/MovieTheatreNetworks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieTheatreNetwork(int id)
        {
            var movieTheatreNetwork = await _context.MovieTheatres.FindAsync(id);
            if (movieTheatreNetwork == null)
            {
                return NotFound();
            }

            _context.MovieTheatres.Remove(movieTheatreNetwork);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieTheatreNetworkExists(int id)
        {
            return _context.MovieTheatres.Any(e => e.Id == id);
        }
    }
}
