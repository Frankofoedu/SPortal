﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sportal.Models
{
    public enum Gender
    {
        M = 1, F = 2
    };

    public enum ReligionEnum
    {
        Islam = 1,
        Christian = 2
    }

    public class AppUser : IdentityUser
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Please enter a valid name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Required")]        
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Please enter a valid name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Please enter a valid name")]
        public string OtherNames { get; set; }

        

        [Display(Name = "Sex")]
        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "State")]
        [Required]
        public string StateOfOrigin { get; set; }

        [Required]
        public ReligionEnum Religion { get; set; }

        [Required]
        public string Country { get; set; }

        [Display(Name = "Last Login")]
        [DataType(DataType.DateTime)]
        public DateTime? LastLogin { get; set; }
    }
}
