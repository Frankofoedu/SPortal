using System;
using System.Collections.Generic;
using System.Text;

namespace Sportal.Models
{
    public class Parent: AppUser
    {
        public string AltPhoneNumber { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public ICollection<Student> Wards { get; set; }

    }
}
