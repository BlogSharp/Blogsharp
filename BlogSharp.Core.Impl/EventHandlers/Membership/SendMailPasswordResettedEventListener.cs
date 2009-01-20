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
	public class SendMailPasswordResettedEventListener:IEventListener<PasswordResettedEventArgs>
	{
		public SendMailPasswordResettedEventListener(IMailService mailService,ITemplateEngine engine,ITemplateSource templateSource)
		{
			this.mailService = mailService;
			this.templateEngine = engine;
			this.templateSource = templateSource;
		}
		private readonly ITemplateSource templateSource;
		private readonly IMailService mailService;
		private readonly ITemplateEngine templateEngine;
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
