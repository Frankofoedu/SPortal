using System;
using System.Collections.Generic;
using System.Text;

namespace Sportal.Models
{
    public class Subject
    {
        public Guid SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Guid dClassID { get; set; }
        public string StaffID { get; set; }
        public virtual ICollection<Student> Students { get; set; }
               
    }

}
