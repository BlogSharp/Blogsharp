namespace BlogSharp.Core.Impl.Services.Mail
{
	using System.Net.Mail;
	using Core.Services.Mail;

	public class MailService : IMailService
	{
		private readonly string defaultDisplayName;
		private readonly string defaultFromAddress;
		private readonly SmtpClient smtpClient;

		public MailService(string defaultFromAddress, string defaultDisplayName, string host, int port)
		{
			this.defaultFromAddress = defaultFromAddress;
			this.defaultDisplayName = defaultDisplayName;
			smtpClient = new SmtpClient(host, port);
		}

		#region IMailService Members

		public void Send(MailAddress to, MailAddress from, MailAddress replyto, string subject, string message)
		{
			MailMessage m = new MailMessage(from, to);
			m.ReplyTo = replyto;
			m.Subject = subject;
			m.Body = message;
			smtpClient.Send(m);
		}

		public void Send(MailAddress to, MailAddress replyto, string subject, string message)
		{
			Send(to, replyto, new MailAddress(defaultFromAddress, defaultDisplayName),
			     subject, message);
		}

		public void Send(MailAddress to, string subject, string message)
		{
			Send(to, null, new MailAddress(defaultFromAddress, defaultDisplayName),
			     subject, message);
		}

		#endregion
	}
}