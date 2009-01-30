﻿using System.Collections.Generic;
using System.Net.Mail;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
	public class SendMailPasswordResettedEventListener : IEventListener<PasswordResettedEventArgs>
	{
		private readonly IMailService mailService;
		private readonly ITemplateEngine templateEngine;
		private readonly ITemplateSource templateSource;

		public SendMailPasswordResettedEventListener(IMailService mailService, ITemplateEngine engine,
		                                             ITemplateSource templateSource)
		{
			this.mailService = mailService;
			templateEngine = engine;
			this.templateSource = templateSource;
		}

		#region IEventListener<PasswordResettedEventArgs> Members

		public void Handle(PasswordResettedEventArgs eventArgs)
		{
			var user = eventArgs.User;
			var dictionary = new Dictionary<string, object>();
			dictionary.Add("user", user);
			dictionary.Add("newPassword", eventArgs.NewPassword);
			ITemplate template = templateSource.GetTemplateWithKey("membership_passwordreset");
			string output = templateEngine.Merge(template, dictionary);
			mailService.Send(new MailAddress(user.Email, user.Username), null, null, "Password Reset Request", output);
		}

		#endregion
	}
}