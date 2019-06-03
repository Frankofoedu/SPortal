using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortal.DAL
{
	public class Announcement
	{
		public int AnnouncementID { get; set; }
		public bool isPublished { get; set; }
		public int SenderStaff { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public string Target { get; set; }
		public string Category { get; set; }
		public DateTime ExpiryDate { get; set; }


		
	}
}