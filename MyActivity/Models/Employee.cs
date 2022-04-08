using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyActivity.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required()]
        public string FirstName { get; set; }

        [Required()]
        public string LastName { get; set; }

        [Required()]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]

        public string EmailId { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Number is not valid")]

        public long MobileNo { get; set; }

        [NotMapped]

        public string ActivityName { get; set; }
        //public int ActivityEnrollmentId { get; set; }

        //[ForeignKey("ActivityEnrollmentId")]
        //public ActivityEnrollment ActivityEnrollment { get; set; }
    }
}
