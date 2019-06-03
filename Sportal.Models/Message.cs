using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sportal.Models
{
	public class Message
	{
		public int MessageID { get; set; }
		public bool isRead { get; set; }
		public string FromType { get; set; }
		public string ToType { get; set; }
		public int FromID { get; set; }
		public int ToID { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime Time { get; set; }

		
	}
}