using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService
{
  public class EmailConfiguration
	{
		public string From { get; set; }
		public string To { get; set; }
		public string SmptServer { get; set; }
		public int Port { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

	}
}
