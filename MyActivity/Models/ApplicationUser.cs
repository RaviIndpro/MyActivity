﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyActivity.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string Name { get; set; }
        //public string City { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
