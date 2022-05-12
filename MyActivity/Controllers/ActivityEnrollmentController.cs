using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Models;
using MyActivity.ViewModel;

namespace MyActivity.Controllers
{
    public class ActivityEnrollmentController : Controller
    {
        private readonly ILogger<ActivityEnrollmentController> _logger;

        private readonly ApplicationDbContext _db;


        //public ActivityEnrollmentController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}
        public ActivityEnrollmentController(ApplicationDbContext db, ILogger<ActivityEnrollmentController> logger)
        {
            _db = db;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected Enrollments Controller");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //var objEmployeeActivityList = _db.ActivityEnrollments.Include(x=>x.Employee).Include(x=>x.EmployeeActivity)
            //    .GroupBy(c=> c.Employee.FirstName)
            //    .Select(d=>new ActivityEnrollment
            //    {
            //    //    Id= x.Id,
            //        EmployeeName = d.Key,
            //        ActivityName = string.Join(", ", d.Select(e=>e.EmployeeActivity.ActivityName))
            //    });

            var objEmployeeActivityList = _db.ActivityEnrollments.Include(x => x.ApplicationUser).Include(x => x.EmployeeActivity)
                .GroupBy(c => c.ApplicationUser.Name)
                .Select(d => new ActivityEnrollment
                {
                    //    Id= x.Id,
                    EmployeeName = d.Key,
                    ActivityName = string.Join(", ", d.Select(e => e.EmployeeActivity.ActivityName))
                });

            return View(objEmployeeActivityList);
        }

        //public JsonResult IsEmployeeExist(string Employee)
        //{
        //    return Json(_db.EmployeeActivities.Any(x => x.Employee == Employee), JsonRequestBehavior.AllowGet);
        //}

        //GET
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.Employees.Select(i => new SelectListItem
            //{
            //    Text = i.FirstName,
            //    Value = i.Id.ToString()
            //});

            IEnumerable<SelectListItem> TypeDropDown = _db.ApplicationUsers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });


            IEnumerable<SelectListItem> TypeDropDown2 = _db.EmployeeActivities.Select(i => new SelectListItem
            {
                Text = i.ActivityName,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;
            ViewBag.TypeDropDown2 = TypeDropDown2;

            //EnrollmentViewModel EnrollmentviewModel = new EnrollmentViewModel()
            //{
            //    ActivityEnrollment = new ActivityEnrollment(),
            //}
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivityEnrollment obj)
        {
            //if (ModelState.IsValid)
            //{
            //var count = _db.ActivityEnrollments.Where(x => x.ApplicationUser.UserId == obj.ApplicationUser.UserId).Count();
            var count = 1;

                if (count < 4)
                {
                    var count2 = _db.ActivityEnrollments.Where(x => x.ApplicationUserId == obj.ApplicationUserId
                    && x.EmployeeActivityId == obj.EmployeeActivityId).Count();
                    if (count2 == 0)
                    {
                        _db.ActivityEnrollments.Add(obj);
                        _db.SaveChanges();
                        TempData["success"] = "Successfully Registered";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Duplicate1 = "This Activity is already selected";
                        _logger.LogInformation("CREATE POST - Duplicate Activity!");


                    }


                }
                else
                {
                    ViewBag.Duplicate2 = "Sorry, You cannot select more than 4 Activity";
                }


            //}
            IEnumerable<SelectListItem> TypeDropDown = _db.ApplicationUsers.Select(i => new SelectListItem
            {
                Text = i.Name,
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




        //public IActionResult Create()
        //{
        //    List<SelectListItem> EmployeeList = GetEmployees();
        //    return View(EmployeeList);
        //}

        //[HttpPost]
        //public IActionResult Create(string[] Employees)
        //{
        //    List<SelectListItem> EmployeeList = GetEmployees();
        //    ViewBag.Message = "";
        //    foreach (string Id in Employees)
        //    {
        //        SelectListItem selectedItem = EmployeeList.Find(p => p.Value == Id);
        //        ViewBag.Message += "Name: " + selectedItem.Text;
        //        ViewBag.Message += "\\nID: " + selectedItem.Value;
        //        ViewBag.Message += "\\n";
        //    }
        //    return View(EmployeeList);
        //}

        //private static List<SelectListItem> GetEmployees()
        //{
        //    EmployeeEntities entities = new EmployeeEntities();
        //    List<SelectListItem> EmployeeList = (from p in entities.Employees.AsIEnumerable()
        //                                         select new SelectListItem
        //                                         {
        //                                             Text = p.FirstName,
        //                                             Value = p.Id.ToString()
        //                                         }).ToList();

        //    //Add Default Item at First Position.
        //    EmployeeList.Insert(0, new SelectListItem { Text = "--Select Employee--", Value = "" });

        //    return EmployeeList;
        //}
        //GET
        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Employees.Select(i => new SelectListItem
            {
                Text = i.FirstName,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> TypeDropDown2 = _db.EmployeeActivities.Select(i => new SelectListItem
            {
                Text = i.ActivityName,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;
            ViewBag.TypeDropDown2 = TypeDropDown2;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ActivityEnrollmentFromDb = _db.ActivityEnrollments.Find(id);
            if (ActivityEnrollmentFromDb == null)
            {
                return NotFound();
            }
            return View(ActivityEnrollmentFromDb);
            //return View(ActivityEnrollmentFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ActivityEnrollment obj)
        {
            if (ModelState.IsValid)
            {
                //var count = _db.ActivityEnrollments.Where(x => x.EmployeeId == obj.EmployeeId).Count();
                //if (count < 4)
                //{
                    _db.ActivityEnrollments.Update(obj);
                    _db.SaveChanges();
                //}

                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET
        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Employees.Select(i => new SelectListItem
            {
                Text = i.FirstName,
                Value = i.Id.ToString()
            });
            IEnumerable<SelectListItem> TypeDropDown2 = _db.EmployeeActivities.Select(i => new SelectListItem
            {
                Text = i.ActivityName,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;
            ViewBag.TypeDropDown2 = TypeDropDown2;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ActivityEnrollmentFromDb = _db.ActivityEnrollments.Find(id);
            if (ActivityEnrollmentFromDb == null)
            {
                return NotFound();
            }
            return View(ActivityEnrollmentFromDb);
            
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            //if (ModelState.IsValid)
            //{
            //    //var count = _db.ActivityEnrollments.Where(x => x.EmployeeId == obj.EmployeeId).Count();
            //    //if (count < 4)
            //    //{
            //    //    _db.ActivityEnrollments.Update(obj);
            //    //    _db.SaveChanges();
            //    //}

            //    return RedirectToAction("Index");
            //}
            //return View(obj);
            var obj = _db.ActivityEnrollments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.ActivityEnrollments.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            //return View(obj);

        }


    }
}

