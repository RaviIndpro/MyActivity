using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Dto;
using MyActivity.Models;

namespace MyActivity.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VenuesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Venues
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        //{
        //    return await _context.Venues.ToListAsync();
        //}

        public ActionResult<IEnumerable<VenueReadDto>> Get()
        {
            var contexts = _context;
            var venueDetails = contexts.Venues.ToList();
            var contextsDto = _mapper.Map<IEnumerable<VenueReadDto>>(venueDetails);
            if(contexts == null)
            {
                return NotFound();
            }
            return Ok(contextsDto);
        }

        //public async Task<ActionResult<IEnumerable<VenueReadDto>>> Get()
        //{
        //    return await _context.Venues.ToListAsync();
        //}

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);

            if (venue == null)
            {
                return NotFound();
            }

            return venue;
        }

        // PUT: api/Venues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue(int id, Venue venue)
        {
            if (id != venue.Id)
            {
                return BadRequest();
            }

            _context.Entry(venue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueExists(id))
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

        // POST: api/Venues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venue>> PostVenue(Venue venue)
        {
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenue", new { id = venue.Id }, venue);
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenueExists(int id)
        {
            return _context.Venues.Any(e => e.Id == id);
        }
    }
}
