using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.Event;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Template;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
	public class UserRegisteredEventListener:IEventListener<UserRegisteredEvent>
	{
		public UserRegisteredEventListener(IMailService mailService,
											ITemplateEngine templateEngine)
		{
			this.mailService = mailService;
			this.templateEngine = templateEngine;
		}

		private readonly ITemplateEngine templateEngine;
		private readonly IMailService mailService;
		#region IEventListener<UserRegisteredEvent> Members

		//TODO: Localization is necessary
		public void Handle(UserRegisteredEvent @event)
		{
			IAuthor user = @event.User;
			string merged = templateEngine.Merge(null, null);
			mailService.Send(new MailAddress(user.Email, user.Username), null, null, "Registration information", merged);
		}

		#endregion
	}
}
