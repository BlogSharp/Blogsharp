namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using Core.Services.Mail;
    using Core.Services.Template;
    using Event.MembershipEvents;
    using Model;

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
            ITemplate template = this.templateSource.GetTemplateWithKey("membership_welcome");
            var context = new Dictionary<string, object>();
            context["user"] = user;
            string merged = this.templateEngine.Merge(template, context);
            this.mailService.Send(new MailAddress(user.Email, user.UserName), null, null, "Registration information", merged);
        }

        #endregion
    }
}