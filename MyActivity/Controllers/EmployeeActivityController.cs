using Microsoft.AspNetCore.Mvc;
using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Controllers
{
    public class EmployeeActivityController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeActivityController(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        {
            IEnumerable<EmployeeActivity> objEmployeeActivityList = _db.EmployeeActivities;
            return View(objEmployeeActivityList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeActivity obj)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeActivities.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Activity Created Successfully";

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
            var EmployeeActivityFromDb = _db.EmployeeActivities.Find(id);
            if (EmployeeActivityFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeActivityFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeActivity obj)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeActivities.Update(obj);
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
            var EmployeeActivityFromDb = _db.EmployeeActivities.Find(id);
            if (EmployeeActivityFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeActivityFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.EmployeeActivities.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.EmployeeActivities.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Activity deleted Successfully";

            return RedirectToAction("Index");

            //return View(obj);

        }

    }


}
