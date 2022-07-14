using System.ComponentModel.DataAnnotations;

namespace MyActivity.Models
{
    public class TestChart
    {
        [Key]
        public int Id { get; set; }
        public string ActivityName2 { get; set; }
        public int EmpEnrolled { get; set; }
    }
}
