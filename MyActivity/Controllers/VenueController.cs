using Microsoft.AspNetCore.Mvc;
using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ActivityEnrollmentController> _logger;


        public VenueController(ApplicationDbContext db, ILogger<ActivityEnrollmentController> logger)
        {
            _db = db;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected Enrollments Controller");
        }
        public IActionResult Index()
        {
            IEnumerable<Venue> objVenueList = _db.Venues;
            return View(objVenueList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venue obj)
        {
            if (ModelState.IsValid)
            {
                _db.Venues.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Activity Created Successfully";
                _logger.LogInformation("Added a New Venue");


                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var VenueFromDb = _db.Venues.Find(id);
            if (VenueFromDb == null)
            {
                return NotFound();
            }
            return View(VenueFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venue obj)
        {
            if (ModelState.IsValid)
            {
                _db.Venues.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Activity Updated Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var VenueFromDb = _db.Venues.Find(id);
            if (VenueFromDb == null)
            {
                return NotFound();
            }
            return View(VenueFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Venues.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Venues.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Activity deleted Successfully";
            _logger.LogInformation("Deleted a venue");


            return RedirectToAction("Index");

            //return View(obj);

        }
    }
}
