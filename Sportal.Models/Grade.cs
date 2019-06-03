using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sportal.Models
{
	public class Grade
	{
		public int GradeID { get; set; }
		public int SubjectID { get; set; }
		public int StaffID { get; set; }
		public int StudentID { get; set; }
		public int Score { get; set; }
		public string Term { get; set; }
		public string Session { get; set; }
		public DateTime? ExamDate { get; set; }


	}
}