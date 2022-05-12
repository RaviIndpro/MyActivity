using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Controllers
{
    public class VenueEnrollmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VenueEnrollmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<VenueEnrollment> obj = _db.VenueEnrollments.Include(x => x.Venue).Include(x => x.EmployeeActivity);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {          

            IEnumerable<SelectListItem> TypeDropDown = _db.EmployeeActivities.Select(i => new SelectListItem
            {
                Text = i.ActivityName,
                Value = i.Id.ToString()
            });

            IEnumerable<SelectListItem> TypeDropDown2 = _db.Venues.Select(i => new SelectListItem
            {
                Text = i.StadiumName,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;
            ViewBag.TypeDropDown2 = TypeDropDown2;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VenueEnrollment obj)
        {
            //if (ModelState.IsValid)
            //{
            //var count = _db.VenueEnrollments.Where(x => x.Venue.Id == obj.Venue.Id).Count();


            //if (count < 4)
            //{
                //var count2 = _db.ActivityEnrollments.Where(x => x.ApplicationUser.UserId == obj.ApplicationUser.UserId
                //&& x.EmployeeActivityId == obj.EmployeeActivityId).Count();
                //if (count2 == 0)
                //{
                _db.VenueEnrollments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Registered";
                return RedirectToAction("Index");
                //}
                //else
                //{
                //    ViewBag.Duplicate1 = "This Activity is already selected";
                //    // _logger.LogInformation("CREATE POST - Duplicate Activity!");


                //}


            //}
           // else
           // {
           //     ViewBag.Duplicate2 = "Sorry, You cannot select more than 4 Activity";
           // }


            //}
            IEnumerable<SelectListItem> TypeDropDown = _db.Venues.Select(i => new SelectListItem
            {
                Text = i.StadiumName,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> TypeDropDown2 = _db.EmployeeActivities.Select(i => new SelectListItem
            {
                Text = i.ActivityName,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;
            ViewBag.TypeDropDown2 = TypeDropDown2;
            return View(obj);


        }
    }
}
