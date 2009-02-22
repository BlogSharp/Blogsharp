namespace BlogSharp.Db4o.Tests.Repositories
{
	using Blog.Repositories;
	using Core.Persistence.Repositories;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class UserRepositoryTest : BaseTest
	{
		#region Setup/Teardown

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			userRepository = new UserRepository(objectContainerManager);
		}

		#endregion

		private IUserRepository userRepository;

		[Test]
		public void Can_delete_an_user()
		{
			var user = new User();
			user.ID = 1;
			userRepository.SaveUser(user);
			userRepository.RemoveUser(user);
			var id = objectContainer.GetID(user);
			Assert.True(id == 0);
		}

		[Test]
		public void Can_get_by_email()
		{
			var user = new User();
			user.ID = 1;
			user.Email = "TestUserEmail";
			userRepository.SaveUser(user);

			var foundUser = userRepository.GetAuthorByEmail("TestUserEmail");
			Assert.NotNull(foundUser);
			Assert.AreEqual(1, foundUser.ID);
			Assert.AreEqual("TestUserEmail", foundUser.Email);
		}

		[Test]
		public void Can_get_by_username()
		{
			var user = new User();
			user.ID = 1;
			user.Username = "TestUser";
			objectContainer.Store(user);

			var foundUser = userRepository.GetAuthorByUsername("TestUser");
			Assert.NotNull(foundUser);
			Assert.AreEqual(1, foundUser.ID);
			Assert.AreEqual("TestUser", foundUser.Username);
		}

		[Test]
		public void Can_store_an_user()
		{
			var user = new User();
			userRepository.SaveUser(user);
			var id = objectContainer.GetID(user);
			Assert.True(id > 0);
		}
	}
}