using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.Event;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Template;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
	public class PasswordResettedEventListener:IEventListener<PasswordResettedEvent>
	{
		public PasswordResettedEventListener(IMailService mailService,ITemplateEngine engine)
		{
			this.mailService = mailService;
			this.templateEngine = engine;
		}

		private readonly IMailService mailService;
		private readonly ITemplateEngine templateEngine;
		#region IEventListener<PasswordResettedEvent> Members

		public void Handle(PasswordResettedEvent @event)
		{
			IAuthor author = @event.Author;
			DefaultContext context=new DefaultContext();
			context.Put(new {author = author, newPassword = @event.NewPassword});
			ITemplate template = null;
			string output = templateEngine.Merge(template, context);
			mailService.Send(new MailAddress(author.Email, author.Username), null, null, "Password Reset Request", output);
		}

		#endregion
	}
}
