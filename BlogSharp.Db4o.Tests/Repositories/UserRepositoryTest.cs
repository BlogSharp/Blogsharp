using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Db4o.Repositories;
using BlogSharp.Db4o.Tests;
using BlogSharp.Model;
using Db4objects.Db4o;
using Xunit;

namespace BlogSharp.Db4o.Tests.Repositories
{
	public class UserRepositoryTest : BaseTest
	{
		private readonly IUserRepository userRepository;

		public UserRepositoryTest()
		{
			this.userRepository = new UserRepository(this.objectContainerManager);
		}

		[Fact]
		public void Can_store_an_user()
		{
			var user = GetEntityFactory<IUser>().Create();
			userRepository.SaveUser(user);
			var id = objectContainer.GetID(user);
			Assert.True(id>0);
		}

		[Fact]
		public void Can_delete_an_user()
		{
			var user = GetEntityFactory<IUser>().Create();
			user.Id = 1;
			userRepository.SaveUser(user);
			userRepository.RemoveUser(user);
			var id = objectContainer.GetID(user);
			Assert.True(id==0);
		}

		[Fact]
		public void Can_get_by_username()
		{
			var user = GetEntityFactory<IUser>().Create();
			user.Id = 1;
			user.Username = "TestUser";
			objectContainer.Store(user);

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