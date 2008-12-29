using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.DataAccess
{
	public class UserRepositoryTest : BaseTest
	{
		private readonly IObjectContainer objectContainer;
		private readonly IUserRepository userRepository;

		public UserRepositoryTest()
		{
			objectContainer = Db4oFactory.OpenFile("test.db4o");
			userRepository = new UserRepository(objectContainer);
		}

		public override void OnTearDown()
		{
			objectContainer.Close();
			File.Delete(MapPath("test.db4o"));
		}


		[Fact]
		public void Can_store_an_user()
		{
			var user = GetEntityFactory<IUser>().Create();
			userRepository.SaveUser(user);
		}

		[Fact]
		public void Can_delete_an_user()
		{
			var user = GetEntityFactory<IUser>().Create();
			user.Id = 1;
			userRepository.SaveUser(user);
			userRepository.RemoveUser(user);
			var foundUser = userRepository.GetById(1);
			Assert.Null(foundUser);
		}

		[Fact]
		public void Can_get_by_username()
		{
			var user = GetEntityFactory<IUser>().Create();
			user.Id = 1;
			user.Username= "TestUser";
			userRepository.SaveUser(user);

			var foundUser = userRepository.GetAuthorByUsername("TestUser");
			Assert.NotNull(foundUser);
			Assert.Equal(1, foundUser.Id);
			Assert.Equal("TestUser", foundUser.Username);
		}

		[Fact]
		public void Can_get_by_email()
		{
			var user = GetEntityFactory<IUser>().Create();
			user.Id = 1;
			user.Email = "TestUserEmail";
			userRepository.SaveUser(user);

			var foundUser = userRepository.GetAuthorByEmail("TestUserEmail");
			Assert.NotNull(foundUser);
			Assert.Equal(1, foundUser.Id);
			Assert.Equal("TestUserEmail", foundUser.Email);
		}
	}
}
