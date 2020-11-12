using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.Repo
{
	public interface IEmailSender
	{
		void SendEmail(Message message);
	}
}
