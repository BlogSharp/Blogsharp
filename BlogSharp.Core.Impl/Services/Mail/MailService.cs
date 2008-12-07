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
		public MailService(string defaultFromAddress,string defaultDisplayName)
		{
			this.defaultFromAddress = defaultFromAddress;
			this.defaultDisplayName = defaultDisplayName;
		}

		private readonly string defaultDisplayName;
		private readonly string defaultFromAddress;
		public void Send(MailAddress to, MailAddress from, MailAddress replyto, string subject, string message)
		{
			throw new NotImplementedException();
		}
	}
}
