using Microsoft.AspNetCore.Mvc;
using MyActivity.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyActivity.Models
{
    public class ActivityEnrollment
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeActivityId { get; set; }
        //public int EmployeeId { get; set; }
        //public int VenueEnrollmentId { get; set; }

        public string ApplicationUserId { get; set; }
        [NotMapped]

        public string EmployeeName { get; set; }
        [NotMapped]

        public string ActivityName { get; set; }
        //[NotMapped]

       // public string VenueName { get; set; }


        [ForeignKey("EmployeeActivityId")]
        public virtual EmployeeActivity EmployeeActivity { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("VenueEnrollmentId")]
        //public virtual VenueEnrollment VenueEnrollment { get; set; }



        //[ForeignKey("EmployeeId")]
        // [Remote("IsEmployeeExist", "ActivityEnrollmentController",ErrorMessage ="Employee already added")]
        //public virtual Employee Employee { get; set; }
        //[NotMapped]
        //public List<string> ActivityNameList { get; set; }
        [NotMapped]
        public int ActivityCount { get; set; }
        //public List<ActivityFlag> ActivityFlagList { get; set; }

        //public class ActivityFlag
        //{
        //    [Key]
        //    public int Id { get; set; }
        //    public string ActName { get; set; }
        //    public int FlagValue { get; set; }
        //}
    }
}
