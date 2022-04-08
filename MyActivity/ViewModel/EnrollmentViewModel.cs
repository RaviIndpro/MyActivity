using Microsoft.AspNetCore.Mvc.Rendering;
using MyActivity.Models;

namespace MyActivity.ViewModel
{
    public class EnrollmentVM
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public List<EmployeeActivity> ActivityList { get; set; }
        public EmployeeActivity EmployeeActivity { get;  set; }
        public ActivityEnrollment ActivityEnrollment { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown2 { get; set; }



    }
}