using System;
using System.Collections.Generic;
using System.Text;

namespace Sportal.Models
{
   public abstract class User
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string StateOfOrigin { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
