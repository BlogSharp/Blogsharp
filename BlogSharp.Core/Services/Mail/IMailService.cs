using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace BlogSharp.Core.Services.Mail
{
	public interface IMailService
	{
		void Send(MailAddress to, MailAddress from, MailAddress replyto, string subject, string message);

	}
}
