namespace BlogSharp.Core.Impl.Tests.Services.Membership
{
	using Castle.Windsor;
	using Core.Services.Encryption;
	using Core.Services.Membership;
	using Impl.Services.Membership;
	using Model;
	using NUnit.Framework;
	using Persistence.Repositories;
	using Rhino.Mocks;

	[TestFixture]
	public class MembershipServiceTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			userRepository = MockRepository.GenerateMock<IUserRepository>();
			membershipService = new MembershipService(userRepository, MockRepository.GenerateMock<IEncryptionService>());
			var container = MockRepository.GenerateMock<IWindsorContainer>();
		}

		#endregion

		private IMembershipService membershipService;
		private IUserRepository userRepository;

		[Test]
		public void Can_create_new_user_with_password_and_username()
		{
			membershipService.CreateNewUser("username", "password", "email");
			userRepository.AssertWasCalled(
				x =>
				x.SaveUser(Arg<User>.Matches(a => a.UserName == "username" &&
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