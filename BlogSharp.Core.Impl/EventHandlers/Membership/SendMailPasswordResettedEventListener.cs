using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.Event;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Template;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
	public class SendMailPasswordResettedEventListener:IEventListener<IMembershipService,PasswordResettedEventArgs>
	{
		public SendMailPasswordResettedEventListener(IMailService mailService,ITemplateEngine engine)
		{
			this.mailService = mailService;
			this.templateEngine = engine;
		}

		private readonly IMailService mailService;
		private readonly ITemplateEngine templateEngine;
		#region IEventListener<PasswordResettedEventArgs> Members

		public void Handle(IMembershipService membershipService, PasswordResettedEventArgs eventArgs)
		{

			var author = eventArgs.Author;
			DefaultContext context=new DefaultContext();
			context.Put(new {author = author, newPassword = eventArgs.NewPassword});
			ITemplate template = null;
			string output = templateEngine.Merge(template, context);
			mailService.Send(new MailAddress(author.Email, author.Username), null, null, "Password Reset Request", output);
		}

		#endregion
	}
}
