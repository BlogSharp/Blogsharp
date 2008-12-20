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
	public class PasswordResettedEventListenerTests:BaseTest
	{
		public PasswordResettedEventListenerTests()
		{
			mailServiceMock = MockRepository.GenerateMock<IMailService>();
			templateEngineMock = MockRepository.GenerateMock<ITemplateEngine>();
			this.listener = new PasswordResettedEventListener(mailServiceMock, templateEngineMock);
		}

		private readonly IMailService mailServiceMock;
		private readonly ITemplateEngine templateEngineMock;
        private readonly PasswordResettedEventListener listener;

		[Fact]
		public void Calls_template_engine_and_template_source_then_sends_email()
		{
			var authorMock = MockRepository.GenerateMock<IAuthor>();
			authorMock.Expect(x => x.Email).Return("blah@blah.com").Repeat.Any();
			var membershipServiceMock = MockRepository.GenerateMock<IMembershipService>();
			listener.Handle(membershipServiceMock, new PasswordResettedEventArgs(authorMock, "1234"));
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
