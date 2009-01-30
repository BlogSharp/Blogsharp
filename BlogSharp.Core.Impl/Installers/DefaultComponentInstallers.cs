using System.Web;
using System.Web.Mvc;
using BlogSharp.CastleExtensions.Facilities;
using BlogSharp.Core.Impl.Services.Mail;
using BlogSharp.Core.Impl.Services.Post;
using BlogSharp.Core.Impl.Structure;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Post;
using BlogSharp.Core.Structure;
using BlogSharp.MvcExtensions;
using BlogSharp.MvcExtensions.ControllerFactories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BlogSharp.Core.Impl.Installers
{
	public class DefaultComponentInstallers : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, Castle.MicroKernel.IConfigurationStore store)
		{
			container
				.Register(Component.For<IPostService>().ImplementedBy<PostService>())
				.Register(Component.For<IMailService>().ImplementedBy<MailService>())
				.Register(Component.For<IFriendlyUrlGenerator>().ImplementedBy<FriendlyUrlGenerator>())
				.AddFacility<ControllerRegisterFacility>()
				.Register(AllTypes.Of<IController>()
				          	.FromAssemblyNamed("BlogSharp.Web").Configure(x => x.LifeStyle.Transient))
				.Register(Component.For<IExtendedControllerFactory>()
				          	.ImplementedBy<WindsorControllerFactory>())
				.Register(AllTypes.Of<IStartupInstaller>()
				          	.FromAssemblyNamed("BlogSharp.Core.Impl")
				          	.WithService.FirstInterface())
				.Register(AllTypes.Of<IHttpModule>().FromAssemblyNamed("BlogSharp.Core.Impl"));
		}

		#endregion
	}
}