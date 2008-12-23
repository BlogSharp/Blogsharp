using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.Services.Membership;
using BlogSharp.Core.Services.Encryption;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;
using BlogSharp.Model.Impl;
using Castle.Windsor;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.Membership
{
	public class MembershipServiceTests:BaseTest
	{
		public MembershipServiceTests()
		{
			this.userRepository = MockRepository.GenerateMock<IUserRepository>();
			this.membershipService = new MembershipService(userRepository,MockRepository.GenerateMock<IEncryptionService>());
			var container = MockRepository.GenerateMock<IWindsorContainer>();
			var entityFactory= MockRepository.GenerateMock<IEntityFactory<IAuthor>>();
			entityFactory.Expect(x => x.Create()).Return(new Author()).Repeat.Any();
			container.Expect(x => x.Resolve<IEntityFactory<IAuthor>>()).Return(entityFactory).Repeat.Any();
			DI.SetContainer(container);
		}

		private readonly IUserRepository userRepository;
		private readonly IMembershipService membershipService;
		 
		[Fact]
		public void Can_create_new_user_with_password_and_username()
		{
			
			membershipService.CreateNewUser("username", "password", "email");
			this.userRepository.AssertWasCalled(
				x =>
				x.SaveUser(Arg<IAuthor>.Matches(a => a.Username == "username" &&
				                                     a.Password == "password" &&
				                                     a.Email == "email")));
		}

		[Fact]
		public void Can_reset_password()
		{
			var author = new Author {Email = "blah@email.com",Password = "1234"};
			userRepository.Expect(x => x.GetAuthorByEmail("blah@email.com"))
				.Return(author);
			membershipService.ResetPassword("blah@email.com");
			userRepository.AssertWasCalled(x => x.SaveUser(author));
			Assert.NotEqual(author.Password,"1234");
		}
	}
}
