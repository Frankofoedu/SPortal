using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sportal.Models
{
    public class Staff : AppUser
    {
        public string Position { get; set; }
        public string Image { get; set; }
        [Display(Name = "BirthDay")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateOfBirth { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

    }

}
