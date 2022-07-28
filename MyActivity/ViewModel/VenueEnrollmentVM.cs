using MyActivity.Models;

namespace MyActivity.ViewModel
{
    public class VenueEnrollmentVM
    {
        //public int Id { get; set; }
        //public Venue Venue { get; set; }
        //public VenueEnrollment VenueEnrollment { get; set; }
        //public int ActivityCount { get; set; }
        public string ActivityName { get; set; }
        //public string VenueName { get; set; }
        public List<string> StadiumList { get; set; }
        public List<ActivityCounter2> ActivityCounterList { get; set; }

        public class ActivityCounter2
        {
            public string Name { get; set; }
            public int Counter { get; set; }
        }
    }
}
