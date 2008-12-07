using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.Services.Membership;
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
			this.membershipService = new MembershipService();
			var container = MockRepository.GenerateMock<IWindsorContainer>();
			this.authorRepository = MockRepository.GenerateMock<IRepository<IAuthor>>();
			container.Expect(x => x.Resolve<IRepository<IAuthor>>()).Return(this.authorRepository).Repeat.Any();
			var entityFactory= MockRepository.GenerateMock<IEntityFactory<IAuthor>>();
			entityFactory.Expect(x => x.Create()).Return(new Author());
			container.Expect(x => x.Resolve<IEntityFactory<IAuthor>>()).Return(entityFactory);
			DI.SetContainer(container);
		}

		private IRepository<IAuthor> authorRepository;
		private readonly IMembershipService membershipService;
		 
		[Fact]
		public void Can_create_new_user_with_password_and_username()
		{
			
			membershipService.CreateNewUser("username", "password", "email");
			this.authorRepository.AssertWasCalled(
				x => x.Add(Arg<IAuthor>.Matches(a => a.Username == "username" && a.Password == "password" && a.Email == "email")));
		}

		[Fact]
		public void Can_reset_password()
		{
			var list = new List<IAuthor> {new Author {Email = "blah@email.com", Password = "1234"}};
			authorRepository.Expect(x => x.GetByExpression(Arg<Expression<Func<IAuthor,bool>>>.Is.Anything))
				.Return(list);
			membershipService.ResetPassword("blah");
			authorRepository.AssertWasCalled(x => x.Add(list[0]));
		}
	}
}
