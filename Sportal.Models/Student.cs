using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sportal.Models
{
    public class Student: User
    {
        
        public Guid? SectionID { get; set; }
        public Guid? ParentID { get; set; }
        public string RegNo { get; set; }
        public string Password { get; set; }     
        public string Image { get; set; }
        public Section Section { get; set; }
        public Parent Parent { get; set; }
       
    }

}
