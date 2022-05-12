using Microsoft.AspNetCore.Mvc;
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
        public string ApplicationUserId { get; set; }
        [NotMapped]

        public string EmployeeName { get; set; }
        [NotMapped]

        public string ActivityName { get; set; }


        [ForeignKey("EmployeeActivityId")]
        public virtual EmployeeActivity EmployeeActivity { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }



        //[ForeignKey("EmployeeId")]
       // [Remote("IsEmployeeExist", "ActivityEnrollmentController",ErrorMessage ="Employee already added")]
        //public virtual Employee Employee { get; set; }

    }
}
