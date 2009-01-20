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
	public class SendWelcomeEmailUserRegisteredEventListener:IEventListener<UserRegisteredEventArgs>
	{
		public SendWelcomeEmailUserRegisteredEventListener(IMailService mailService,
											ITemplateEngine templateEngine,ITemplateSource templateSource)
		{
			this.mailService = mailService;
			this.templateEngine = templateEngine;
			this.templateSource = templateSource;
		}

		private readonly ITemplateSource templateSource;
		private readonly ITemplateEngine templateEngine;
		private readonly IMailService mailService;
		#region IEventListener<UserRegisteredEventArgs> Members

		//TODO: Localization is necessary
		public void Handle(UserRegisteredEventArgs eventArgs)
		{
			IUser user = eventArgs.User;
			ITemplate template = templateSource.GetTemplateWithKey("membership_welcome");
			var context = new Dictionary<string,object>();
			context["user"] = user;
			string merged = templateEngine.Merge(template, context);
			mailService.Send(new MailAddress(user.Email, user.Username), null, null, "Registration information", merged);
		}

		#endregion
	}
}
