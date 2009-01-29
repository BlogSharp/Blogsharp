using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.Event;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Impl.EventHandlers.Membership;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Template;
using BlogSharp.Model;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.EventHandlers.Membership
{
	public class UserRegisteredEventListenerTests:BaseTest
	{
		public UserRegisteredEventListenerTests()
		{
			this.mailServiceMock = MockRepository.GenerateMock<IMailService>();
			this.templateEngineMock = MockRepository.GenerateMock<ITemplateEngine>();
			this.templateSourceMock = MockRepository.GenerateMock<ITemplateSource>();
			this.listener = new SendWelcomeEmailUserRegisteredEventListener(mailServiceMock, templateEngineMock,templateSourceMock);

		}

		private readonly ITemplateSource templateSourceMock;
		private readonly IMailService mailServiceMock;
		private readonly ITemplateEngine templateEngineMock;
        private readonly SendWelcomeEmailUserRegisteredEventListener listener;

		[Fact]
		public void Calls_templateEngine_and_templateSource_then_sends_email()
		{
			var author = new User {Email = "blah@blah.com"};
			var membershipServiceMock = MockRepository.GenerateMock<IMembershipService>();
			listener.Handle(new UserRegisteredEventArgs(membershipServiceMock, author));
			templateSourceMock.AssertWasCalled(x => x.GetTemplateWithKey("membership_welcome"));
			mailServiceMock.AssertWasCalled(x => x.Send(
			                                     	Arg<MailAddress>.Matches(y => y.Address == "blah@blah.com"),
			                                     	Arg<MailAddress>.Is.Anything,
			                                     	Arg<MailAddress>.Is.Anything,
			                                     	Arg<string>.Is.Anything,
			                                     	Arg<string>.Is.Anything
			                                     	));
		}
	}
}
