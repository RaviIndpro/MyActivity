using MyActivity.Models;

namespace MyActivity.ViewModel
{
    public class VenueEnrollmentVM
    {
        public int Id { get; set; }
        public Venue Venue { get; set; }
        public VenueEnrollment VenueEnrollment { get; set; }
        public List<EmployeeActivity> ActivityList { get; set; }
    }
}
