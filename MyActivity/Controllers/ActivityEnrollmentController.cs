using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyActivity.Data;
using MyActivity.Models;
using MyActivity.ViewModel;
using Newtonsoft.Json;
using static MyActivity.Models.ActivityEnrollment;
using static MyActivity.ViewModel.ActivityEnrollmentVM;

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
            //var objEmployeeActivityList1 = _db.ActivityEnrollments.Include(x=>x.ApplicationUser).Include(x=>x.EmployeeActivity).Select(x=>x).ToList();
           

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
        public IActionResult ShowChart()
        {
            return View();
        }

        //public List<object> GetChartData()
        //{
        //    List<object> data = new List<object>();
        //    List<string> labels = _db.EmployeeActivities.Select(x => x.ActivityName).ToList();
        //    data.Add(labels);
        //    List<int> NoOfEmployees = 1;
        //    data.Add(NoOfEmployees);

        //    var item = _db.ActivityEnrollments.Include(x => x.EmployeeActivity).ToList();
        //    return View(item);
        //}
        //[HttpGet]
        //public JsonResult ActivityChartData()
        //{
        //    var item = _db.ActivityEnrollments.Include(x => x.ApplicationUser).Include(x => x.EmployeeActivity);

        //    var enrollmentGroupByEmployee = item.GroupBy(c => c.ApplicationUser.Name)
        //    .Select(d => new ActivityEnrollment
        //    {
        //        EmployeeName = d.Key,
        //        //ActivityNameList = e => e.EmployeeActivity.ActivityName.ToList(),
        //        //ActivityFlagList = FlagMod(d.Select(g => g.ActivityName).ToList())
        //        ActivityName = string.Join(", ", d.Select(e => e.EmployeeActivity.ActivityName)),

        //        ActivityCount = d.Count()

        //    });

        //    //DataTable dt = (DataTable)JsonConvert.DeserializeObject(enrollmentGroupByEmployee, typeof(DataTable));

        //    //return Json(enrollmentGroupByEmployee);
        //    return Json(enrollmentGroupByEmployee);
        //    //return View(Json(enrollmentGroupByEmployee));
        //}



        //public ActionResult OnGetChartData()
        //{
        //    var data2 = _db.ActivityEnrollments.Include(x => x.ApplicationUser).Include(x => x.EmployeeActivity);
        //    var enrollmentGroupByEmployee2 = data2.GroupBy(c => c.ApplicationUser.Name)
        //    .Select(d => new ActivityEnrollment
        //    {
        //        EmployeeName = d.Key,

        //        ActivityName = string.Join(", ", d.Select(e => e.EmployeeActivity.ActivityName)),
        //        ActivityCount = d.Count()

        //    });

        //    var json = enrollmentGroupByEmployee2.ToGoogleDataTable()
        //            .NewColumn(new Column(ColumnType.String, "Employee"), x => x.EmployeeName)
        //            .NewColumn(new Column(ColumnType.Number, "ActivityCount"), c => c.ActivityCount)
        //            .Build()
        //            .GetJson();

        //    return Content(json);
        //}
        [HttpGet]

        public JsonResult GetActivityChart()
        {
            var item4 = _db.ActivityEnrollments.Include(x => x.ApplicationUser).Include(x => x.EmployeeActivity).ToList();
            

            var enrollmentGroupByEmployee4 = item4.GroupBy(c => c.ApplicationUser.Name).Select(d => new ActivityEnrollmentVM
            {
                Employeename = d.Key,
                //ActivityName = string.Join(", ", d.Select(e => e.EmployeeActivity.ActivityName)),
                ActivityList = d.Select(e => e.EmployeeActivity.ActivityName).ToList(),                
                //ActivityList = d.Select(e => e.ActivityName).ToList(),
                ActivityCount = d.Select(c=> c.EmployeeActivity.ActivityName).Count(),
                ActivityCounterList = ActivityListCount(d.Select(c=>c.EmployeeActivity.ActivityName).ToList())
            });
            return Json(enrollmentGroupByEmployee4);

        }
        public List<ActivityCounter> ActivityListCount(List<string> enrolledActivity)
        {
            List<ActivityCounter> result = new List<ActivityCounter>();
            var listOfActivity = _db.EmployeeActivities.Select(x => x.ActivityName).ToList();

            foreach (var row in listOfActivity)
            {
                result.Add(new ActivityCounter { Name = row, Counter = 0 });
            }
            foreach (var row in result)
            {
                foreach (var col in enrolledActivity)
                {
                    if (row.Name == col)
                    {
                        row.Counter = 1;
                        break;
                    }
                }
            }
            return result;
        }



    }
}

