using System;
using System.Collections.Generic;
using System.Text;

namespace Sportal.Models
{
    public class Section
    {
        public Guid SectionID { get; set; }
        public Guid ClassID { get; set; }
        public string SectionName { get; set; }
        public string Decription { get; set; }
        public Guid StaffID { get; set; }
        public ICollection<Student> Students { get; set; }

    }

}
