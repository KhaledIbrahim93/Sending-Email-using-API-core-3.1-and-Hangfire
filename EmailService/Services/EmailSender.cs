using EmailService.Repo;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Text;

namespace EmailService.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly EmailConfiguration emailConfig;
		public EmailSender(EmailConfiguration _emailConfig)
		{
			emailConfig = _emailConfig;
		}
		
		public void SendEmail(Message message)
		{
			var emailMessage = CreateMessage(message);

			SendMessage(emailMessage);
		}
		private MimeMessage CreateMessage(Message message)
		{
			var emailMessge = new MimeMessage();
			emailMessge.From.Add(new MailboxAddress(emailConfig.From));
			emailMessge.To.AddRange(message.To);
			emailMessge.Subject = message.Subject;
			emailMessge.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text =string.Format("<h2 style='color: blue;'>{0}</h2>" ,message.Content) };
			return emailMessge;
		}
		private void SendMessage(MimeMessage message)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect(emailConfig.SmptServer, emailConfig.Port, true);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					client.Authenticate(emailConfig.UserName, emailConfig.Password);
					client.Send(message);
				}
				catch (Exception ex)
				{

					throw ex;
				}
				finally
				{
					client.Disconnect(true);
					client.Dispose();
				}
			}
		}
	}
}
