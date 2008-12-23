using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.Services.Mail;

namespace BlogSharp.Core.Impl.Services.Mail
{
	public class MailService:IMailService
	{
		public MailService(string defaultFromAddress,string defaultDisplayName,string host,int port)
		{
			this.defaultFromAddress = defaultFromAddress;
			this.defaultDisplayName = defaultDisplayName;
			this.smtpClient = new SmtpClient(host, port);

		}

		private readonly SmtpClient smtpClient;
		private readonly string defaultDisplayName;
		private readonly string defaultFromAddress;
		public void Send(MailAddress to, MailAddress from, MailAddress replyto, string subject, string message)
		{
			MailMessage m=new MailMessage(from,to);
			m.ReplyTo = replyto;
			m.Subject = subject;
			m.Body = message;
			smtpClient.Send(m);
		}

		#region IMailService Members


		public void Send(MailAddress to, MailAddress replyto, string subject, string message)
		{
			this.Send(to, replyto, new MailAddress(this.defaultFromAddress, this.defaultDisplayName),
			          subject, message);
		}

		public void Send(MailAddress to, string subject, string message)
		{
			this.Send(to,null, new MailAddress(this.defaultFromAddress, this.defaultDisplayName),
			          subject, message);
		}

		#endregion
	}
}
