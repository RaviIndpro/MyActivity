using MyActivity.Models;

namespace MyActivity.ViewModel
{
    public class ActivityEnrollmentVM
    {
        //public ApplicationUser ApplicationUser { get; set; }
        //public ActivityEnrollment ActivityEnrollment { get; set; }
        public string Employeename { get; set; }
        public string ActivityName { get; set; }
        public int ActivityCount { get; set; }
        public List<string> ActivityList { get; set; }
        public List<ActivityCounter> ActivityCounterList { get; set; }

        public class ActivityCounter
        {
            public string Name { get; set; }
            public int Counter { get; set; }
        }

    }
}
