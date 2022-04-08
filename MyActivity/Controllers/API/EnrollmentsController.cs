using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiActivityEnrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityEnrollment>>> GetActivityEnrollments()
        {
            return await _context.ActivityEnrollments.ToListAsync();
        }

        // GET: api/ApiActivityEnrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityEnrollment>> GetActivityEnrollment(int id)
        {
            var activityEnrollment = await _context.ActivityEnrollments.FindAsync(id);

            if (activityEnrollment == null)
            {
                return NotFound();
            }

            return activityEnrollment;
        }

        // PUT: api/ApiActivityEnrollments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityEnrollment(int id, ActivityEnrollment activityEnrollment)
        {
            if (id != activityEnrollment.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/ApiActivityEnrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityEnrollment>> PostActivityEnrollment(ActivityEnrollment activityEnrollment)
        {
            _context.ActivityEnrollments.Add(activityEnrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityEnrollment", new { id = activityEnrollment.Id }, activityEnrollment);
        }

        // DELETE: api/ApiActivityEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityEnrollment(int id)
        {
            var activityEnrollment = await _context.ActivityEnrollments.FindAsync(id);
            if (activityEnrollment == null)
            {
                return NotFound();
            }

            _context.ActivityEnrollments.Remove(activityEnrollment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ActivityEnrollmentExists(int id)
        {
            return _context.ActivityEnrollments.Any(e => e.Id == id);
        }
    }
}
