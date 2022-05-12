using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyActivity.Models
{
    public class ApplicationUser :IdentityUser
    {
        //[Key]
        //public int AppUserId { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
    }
}
