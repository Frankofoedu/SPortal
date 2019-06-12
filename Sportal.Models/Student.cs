using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sportal.Models
{
    public class Student: AppUser
    {
        
        public Guid? SectionID { get; set; }

        [ForeignKey("Parent")]
        public string P_ID { get; set; }
        [Display(Name = "BirthDay")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateOfBirth { get; set; }
        public string RegNo { get; set; }   
        public string Image { get; set; }
        public Section Section { get; set; }
        public Parent Parent { get; set; }
       
    }

}
