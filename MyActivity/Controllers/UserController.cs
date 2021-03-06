using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Models;
using System.Linq;

namespace MyActivity.Controllers
{
    //[Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ActivityEnrollmentController> _logger;

        public UserController(ApplicationDbContext db,UserManager<IdentityUser> userManager, ILogger<ActivityEnrollmentController> logger)
        {
            _db = db;
            _userManager = userManager;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected Enrollments Controller");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var userList = _db.ApplicationUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                if(role == null)
                {
                    user.Role = "None";
                }
                else
                {
                    user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }
                
            }
            return View(userList);
        }

        //GET
        //[HttpGet]

        //public IActionResult GetAll()
        //{
            
            
           
        //    return Json(new {data = userList});
        //}
    }
}
