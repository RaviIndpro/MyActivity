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

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        //GET
        [HttpGet]

        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            return Json(new {data = userList});
        }
    }
}
