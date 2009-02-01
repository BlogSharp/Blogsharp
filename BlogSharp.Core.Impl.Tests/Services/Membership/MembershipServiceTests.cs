using BlogSharp.Core.Impl.Services.Membership;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Services.Encryption;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;
using Castle.Windsor;
using Rhino.Mocks;
using NUnit.Framework;

namespace BlogSharp.Core.Impl.Tests.Services.Membership
{
	[TestFixture]
	public class MembershipServiceTests
	{
		private IMembershipService membershipService;
		private IUserRepository userRepository;

		[SetUp]
		public void SetUp()
		{
			userRepository = MockRepository.GenerateMock<IUserRepository>();
			membershipService = new MembershipService(userRepository, MockRepository.GenerateMock<IEncryptionService>());
			var container = MockRepository.GenerateMock<IWindsorContainer>();
		}

		[Test]
		public void Can_create_new_user_with_password_and_username()
		{
			membershipService.CreateNewUser("username", "password", "email");
			userRepository.AssertWasCalled(
				x =>
				x.SaveUser(Arg<User>.Matches(a => a.Username == "username" &&
				                                  a.Password == "password" &&
				                                  a.Email == "email")));
		}

		[Test]
		public void Can_reset_password()
		{
			var author = new User {Email = "blah@email.com", Password = "1234"};
			userRepository.Expect(x => x.GetAuthorByEmail("blah@email.com"))
				.Return(author);
			membershipService.ResetPassword("blah@email.com");
			userRepository.AssertWasCalled(x => x.SaveUser(author));
			Assert.AreNotEqual(author.Password, "1234");
		}
	}
}