namespace BlogSharp.Core.Services.Mail
{
	using System.Net.Mail;

	public interface IMailService
	{
		void Send(MailAddress to, MailAddress from, MailAddress replyto, string subject, string message);
		void Send(MailAddress to, MailAddress replyto, string subject, string message);
		void Send(MailAddress to, string subject, string message);
	}
}