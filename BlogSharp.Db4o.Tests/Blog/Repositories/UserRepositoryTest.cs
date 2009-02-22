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
			this.userRepository = new UserRepository(this.objectContainerManager);
		}

		#endregion

		private IUserRepository userRepository;

		[Test]
		public void Can_delete_an_user()
		{
			var user = new User();
			user.ID = 1;
			this.userRepository.SaveUser(user);
			this.userRepository.RemoveUser(user);
			var id = this.objectContainer.GetID(user);
			Assert.True(id == 0);
		}

		[Test]
		public void Can_get_by_email()
		{
			var user = new User();
			user.ID = 1;
			user.Email = "TestUserEmail";
			this.userRepository.SaveUser(user);

			var foundUser = this.userRepository.GetAuthorByEmail("TestUserEmail");
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
			this.objectContainer.Store(user);

			var foundUser = this.userRepository.GetAuthorByUsername("TestUser");
			Assert.NotNull(foundUser);
			Assert.AreEqual(1, foundUser.ID);
			Assert.AreEqual("TestUser", foundUser.Username);
		}

		[Test]
		public void Can_store_an_user()
		{
			var user = new User();
			this.userRepository.SaveUser(user);
			var id = this.objectContainer.GetID(user);
			Assert.True(id > 0);
		}
	}
}