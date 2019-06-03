using Sportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sportal.Models
{
	public class dClass
	{
		public Guid dClassID { get; set; }
		public string ClassName { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Section> Sections { get; set; }
		public virtual ICollection<Subject> Subjects { get; set; }
    }
}