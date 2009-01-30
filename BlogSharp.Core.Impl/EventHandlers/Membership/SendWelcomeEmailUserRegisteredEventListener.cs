﻿using System.Collections.Generic;
using System.Net.Mail;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Template;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
	public class SendWelcomeEmailUserRegisteredEventListener : IEventListener<UserRegisteredEventArgs>
	{
		private readonly IMailService mailService;
		private readonly ITemplateEngine templateEngine;
		private readonly ITemplateSource templateSource;

		public SendWelcomeEmailUserRegisteredEventListener(IMailService mailService,
		                                                   ITemplateEngine templateEngine, ITemplateSource templateSource)
		{
			this.mailService = mailService;
			this.templateEngine = templateEngine;
			this.templateSource = templateSource;
		}

		//TODO: Localization is necessary

		#region IEventListener<UserRegisteredEventArgs> Members

		public void Handle(UserRegisteredEventArgs eventArgs)
		{
			User user = eventArgs.User;
			ITemplate template = templateSource.GetTemplateWithKey("membership_welcome");
			var context = new Dictionary<string, object>();
			context["user"] = user;
			string merged = templateEngine.Merge(template, context);
			mailService.Send(new MailAddress(user.Email, user.Username), null, null, "Registration information", merged);
		}

		#endregion
	}
}