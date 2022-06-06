using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyActivity.Models
{
    public class VenueEnrollment
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeActivityId { get; set; }
        public int VenueId { get; set; }
        [ForeignKey("EmployeeActivityId")]
        public virtual EmployeeActivity EmployeeActivity { get; set; }
        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }
        [DisplayName("Date")]
        public DateTime GameDate1 { get; set; }

    }
}
