using System.Net.Mail;

namespace BlogSharp.Core.Services.Mail
{
	public interface IMailService
	{
		void Send(MailAddress to, MailAddress from, MailAddress replyto, string subject, string message);
	}
}