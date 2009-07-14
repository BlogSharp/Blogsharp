namespace BlogSharp.Core.Impl.EventHandlers.Membership
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using Core.Services.Mail;
    using Core.Services.Template;
    using Event.MembershipEvents;

    public class SendMailPasswordResettedEventListener : IEventListener<PasswordResettedEventArgs>
    {
        private readonly IMailService mailService;
        private readonly ITemplateEngine templateEngine;
        private readonly ITemplateSource templateSource;

        public SendMailPasswordResettedEventListener(IMailService mailService, ITemplateEngine engine,
                                                     ITemplateSource templateSource)
        {
            this.mailService = mailService;
            this.templateEngine = engine;
            this.templateSource = templateSource;
        }

        #region IEventListener<PasswordResettedEventArgs> Members

        public void Handle(PasswordResettedEventArgs eventArgs)
        {
            var user = eventArgs.User;
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("user", user);
            dictionary.Add("newPassword", eventArgs.NewPassword);
            ITemplate template = this.templateSource.GetTemplateWithKey("membership_passwordreset");
            string output = this.templateEngine.Merge(template, dictionary);
            this.mailService.Send(new MailAddress(user.Email, user.UserName), null, null, "Password Reset Request", output);
        }

        #endregion
    }
}