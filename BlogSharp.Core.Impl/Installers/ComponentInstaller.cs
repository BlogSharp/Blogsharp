using BlogSharp.CastleExtensions.Facilities.Db4o;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.DataAccess;
using BlogSharp.Core.Impl.Services.Model;
using BlogSharp.Core.Services.Model;
using BlogSharp.Model;
using BlogSharp.Model.Impl;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BlogSharp.Core.Impl.Installers
{
	public class ComponentInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IPost>().ImplementedBy<Post>().LifeStyle.Transient);
			container.Register(Component.For<IBlog>().ImplementedBy<Blog>().LifeStyle.Transient);
			container.Register(Component.For<IPostComment>().ImplementedBy<PostComment>().LifeStyle.Transient);
			container.Register(Component.For<ITag>().ImplementedBy<Tag>().LifeStyle.Transient);
			container.Register(Component.For<IUser>().ImplementedBy<Author>().LifeStyle.Transient);

			container.Register(Component.For<IBlogService>().ImplementedBy<BlogService>().LifeStyle.Transient);
			container.Register(Component.For<IPostService>().ImplementedBy<PostService>().LifeStyle.Transient);

			container.Register(Component.For<IBlogRepository>().ImplementedBy<BlogRepository>().LifeStyle.Transient);
			container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifeStyle.Transient);
			container.Register(Component.For<IPostRepository>().ImplementedBy<PostRepository>().LifeStyle.Transient);

			container.AddFacility("db4oSessionManager", new Db4oFacility());
			
		}
	}
}