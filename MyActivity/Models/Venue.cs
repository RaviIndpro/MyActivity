using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyActivity.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StadiumName { get; set; }
       
    }
}
