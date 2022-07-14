using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyActivity.Models;

namespace MyActivity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }      
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }
        public DbSet<ActivityEnrollment> ActivityEnrollments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueEnrollment> VenueEnrollments { get; set; }
        public DbSet<TestChart> TestCharts { get; set; }

    }
}
