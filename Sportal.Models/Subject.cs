using System;
using System.Collections.Generic;
using System.Text;

namespace Sportal.Models
{
    public class Subject
    {
        public Guid SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Guid ClassID { get; set; }
        public Guid StaffID { get; set; }
        public virtual ICollection<Student> Students { get; set; }
               
    }

}
