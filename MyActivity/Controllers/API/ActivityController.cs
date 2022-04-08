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
    public class ActivityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActivityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeActivity>>> GetEmployeeActivities()
        {
            return await _context.EmployeeActivities.ToListAsync();
        }

        // GET: api/EmployeeActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeActivity>> GetEmployeeActivity(int id)
        {
            var employeeActivity = await _context.EmployeeActivities.FindAsync(id);

            if (employeeActivity == null)
            {
                return NotFound();
            }

            return employeeActivity;
        }

        // PUT: api/EmployeeActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeActivity(int id, EmployeeActivity employeeActivity)
        {
            if (id != employeeActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeActivityExists(id))
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

        // POST: api/EmployeeActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeActivity>> PostEmployeeActivity(EmployeeActivity employeeActivity)
        {
            _context.EmployeeActivities.Add(employeeActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeActivity", new { id = employeeActivity.Id }, employeeActivity);
        }

        // DELETE: api/EmployeeActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeActivity(int id)
        {
            var employeeActivity = await _context.EmployeeActivities.FindAsync(id);
            if (employeeActivity == null)
            {
                return NotFound();
            }

            _context.EmployeeActivities.Remove(employeeActivity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool EmployeeActivityExists(int id)
        {
            return _context.EmployeeActivities.Any(e => e.Id == id);
        }
    }
}
