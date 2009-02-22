namespace BlogSharp.Core.Impl.Tests.EventHandlers.Membership
{
	using System.Collections.Generic;
	using System.Net.Mail;
	using Core.Services.Mail;
	using Core.Services.Membership;
	using Core.Services.Template;
	using Event.MembershipEvents;
	using Impl.EventHandlers.Membership;
	using Model;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class PasswordResettedEventListenerTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			mailServiceMock = MockRepository.GenerateMock<IMailService>();
			templateEngineMock = MockRepository.GenerateMock<ITemplateEngine>();
			templateSourceMock = MockRepository.GenerateMock<ITemplateSource>();
			listener = new SendMailPasswordResettedEventListener(mailServiceMock, templateEngineMock, templateSourceMock);
		}

		#endregion

		private SendMailPasswordResettedEventListener listener;
		private IMailService mailServiceMock;
		private ITemplateEngine templateEngineMock;
		private ITemplateSource templateSourceMock;

		[Test]
		public void Calls_template_engine_and_template_source_then_sends_email()
		{
			var author = new User {Email = "blah@blah.com"};
			var membershipServiceMock = MockRepository.GenerateMock<IMembershipService>();
			listener.Handle(new PasswordResettedEventArgs(membershipServiceMock, author, "1234"));
			templateSourceMock.AssertWasCalled(x => x.GetTemplateWithKey("membership_passwordreset"));
			templateEngineMock.AssertWasCalled(
				x => x.Merge(Arg<ITemplate>.Is.Anything, Arg<IDictionary<string, object>>.Is.Anything));
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