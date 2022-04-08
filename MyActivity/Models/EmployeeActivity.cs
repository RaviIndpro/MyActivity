using System.ComponentModel.DataAnnotations;

namespace MyActivity.Models
{
    public class EmployeeActivity
    {
        [Key]
        public int Id { get; set; }

        [Required()]
        public string ActivityName { get; set; }
      //  public string Employee { get; internal set; }
    }
}
