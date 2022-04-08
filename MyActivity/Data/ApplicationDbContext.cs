using Microsoft.EntityFrameworkCore;
using MyActivity.Models;

namespace MyActivity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }      
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }
        public DbSet<ActivityEnrollment> ActivityEnrollments { get; set; }

    }
}
