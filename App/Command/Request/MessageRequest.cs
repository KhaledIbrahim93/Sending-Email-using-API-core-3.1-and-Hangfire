using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Command.Request
{
	public class MessageRequest
	{
		public string To { get; set; }
		public string Content { get; set; }
		public string Subject { get; set; }
	}
}
