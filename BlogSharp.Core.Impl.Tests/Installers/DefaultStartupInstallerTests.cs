using BlogSharp.Core.Impl.Installers;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Structure;
using BlogSharp.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace BlogSharp.Core.Impl.Tests.Installers
{
	[TestFixture]
	public class DefaultStartupInstallerTests
	{
		[Test]
		public void Executes_installer_if_there_is_no_blog()
		{
			var blogRP = MockRepository.GenerateMock<IBlogRepository>();
			var postRP = MockRepository.GenerateMock<IPostRepository>();
			var userRP = MockRepository.GenerateMock<IUserRepository>();
			var friendlyUrlGen = MockRepository.GenerateMock<IFriendlyUrlGenerator>();
			blogRP.Expect(x => x.GetBlog()).Return(null);
			var installer = new DefaultStartupInstaller(blogRP, postRP, userRP, friendlyUrlGen);
			installer.Execute();
			blogRP.AssertWasCalled(x => x.SaveBlog(Arg<Blog>.Is.NotNull));
			userRP.AssertWasCalled(x => x.SaveUser(Arg<User>.Is.NotNull));
			postRP.AssertWasCalled(x => x.SavePost(Arg<Post>.Is.NotNull));
		}
	}
}