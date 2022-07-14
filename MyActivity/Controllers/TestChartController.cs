using Microsoft.AspNetCore.Mvc;
using MyActivity.Models;

namespace MyActivity.Controllers
{
    public class TestChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetPieChartJson()
        {
            List<TestChart> list = new List<TestChart>();
            list.Add(new TestChart { ActivityName2 = "cricket", EmpEnrolled = 2 });
            return Json(new {JSONList = list});
        }
    }
}
