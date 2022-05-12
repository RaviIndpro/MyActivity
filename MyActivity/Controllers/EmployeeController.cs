using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Models;
using System.Linq;

namespace MyActivity.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //private readonly ILogger<EmployeeController> _logger;

        //public EmployeeController(ILogger<EmployeeController>logger)
        //{
        //    _logger = logger;
        //    _logger.Log(LogLevel.Information, "Hi, it's Employee Controller");

        //}

        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
           
           IEnumerable<Employee> objEmployeeList = _db.Employees;
            //_logger.LogInformation("Hi, test");

            //.Include("ActivityEnrollment").ToList();
            return View(objEmployeeList);



            //List<Employee> employees = _db.Employees.ToList();
            //List<ActivityEnrollment> ActivityEnrollments = _db.ActivityEnrollments.
            //    Include(x=>x.EmployeeActivity).Include(x=>x.Employee).ToList();
            //return View(employeeRecord);

            //var objEmployeeActivityList = _db.ActivityEnrollments.Include(x => x.Employee).Include(x => x.EmployeeActivity)
            //   .GroupBy(c => c.Employee.FirstName)
            //   .Select(d => new Employee
            //   {
            //        //    Id= x.Id,
                    
            //       ActivityName = string.Join(", ", d.Select(e => e.EmployeeActivity.ActivityName))
            //   });
            //return View(objEmployeeActivityList);


        }

        //GET
        [HttpGet]
        public IActionResult Create()
        {         
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee created Successfully";
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
            var EmployeeFromDb = _db.Employees.Find(id);
            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee Updated Successfully";
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
            var EmployeeFromDb = _db.Employees.Find(id);
            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Employees.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            
                _db.Employees.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Employee deleted Successfully";
            return RedirectToAction("Index");

          // return View(obj);

        }
    }
}
