namespace BlogSharp.Core.Impl.Tests.Installers
{
	using Core.Structure;
	using Impl.Installers;
	using Model;
	using Model.Validation;
	using NUnit.Framework;
	using Persistence.Repositories;
	using Rhino.Mocks;

	//TODO: Check if blog has the post and post has the blog.

	[TestFixture]
	public class DefaultStartupInstallerTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			blogRP = MockRepository.GenerateMock<IBlogRepository>();
			postRP = MockRepository.GenerateMock<IPostRepository>();
			userRP = MockRepository.GenerateMock<IUserRepository>();
			friendlyUrlGen = MockRepository.GenerateMock<IFriendlyUrlGenerator>();
		}

		#endregion

		private IBlogRepository blogRP;
		private IPostRepository postRP;
		private IUserRepository userRP;
		private IFriendlyUrlGenerator friendlyUrlGen;

		private delegate void Expect<T>(T arg);

		[Test]
		public void Adds_valid_entities_to_repositories()
		{
			friendlyUrlGen.Expect(x => x.GenerateUrl(Arg<string>.Is.Anything, Arg<string[]>.Is.Anything)).Return("aaaa").Repeat.
				Any();
			var blogValidator = new BlogValidator();
			var postValidator = new PostValidator();
			var userValidator = new UserValidator();

			blogRP.Expect(x => x.SaveBlog(Arg<Blog>.Is.Anything))
				.Do(new Expect<Blog>(blogValidator.ValidateAndThrowException));
			userRP.Expect(x => x.SaveUser(Arg<User>.Is.Anything))
				.Do(new Expect<User>(userValidator.ValidateAndThrowException));
			postRP.Expect(x => x.SavePost(Arg<Post>.Is.Anything))
				.Do(new Expect<Post>(postValidator.ValidateAndThrowException));

			var installer = new DefaultStartupInstaller(blogRP, postRP, userRP, friendlyUrlGen);


			installer.Execute();
		}

		[Test]
		public void Executes_installer_if_there_is_no_blog()
		{
			blogRP.Expect(x => x.GetBlog()).Return(null);
			var installer = new DefaultStartupInstaller(blogRP, postRP, userRP, friendlyUrlGen);
			installer.Execute();
			blogRP.AssertWasCalled(x => x.SaveBlog(Arg<Blog>.Is.NotNull));
			userRP.AssertWasCalled(x => x.SaveUser(Arg<User>.Is.NotNull));
			postRP.AssertWasCalled(x => x.SavePost(Arg<Post>.Is.NotNull));
		}
	}
}