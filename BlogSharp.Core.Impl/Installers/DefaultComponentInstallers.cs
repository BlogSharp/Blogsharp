namespace BlogSharp.Core.Impl.Installers
{
	using System.Web;
	using System.Web.Mvc;
	using Castle.MicroKernel.Registration;
	using Castle.Windsor;
	using CastleExtensions.Facilities;
	using Core.Services.Mail;
	using Core.Services.Post;
	using Core.Structure;
	using Model.Validation.Interfaces;
	using MvcExtensions;
	using MvcExtensions.ControllerFactories;
	using Services.Mail;
	using Services.Post;
	using Structure;
	using Web;

	public class DefaultComponentInstallers : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, Castle.MicroKernel.IConfigurationStore store)
		{
			container
				.Register(Component.For<IPostService>()
				          	.ImplementedBy<PostService>())
				.Register(Component.For<IMailService>()
				          	.ImplementedBy<MailService>())
				.Register(Component.For<IFriendlyUrlGenerator>()
				          	.ImplementedBy<FriendlyUrlGenerator>())
				.Register(AllTypes.Of(typeof (IValidatorBase<>))
				          	.FromAssemblyNamed("BlogSharp.Model")
				          	.WithService.FromInterface(typeof (IValidatorBase<>))
				          	.Configure(x => x.LifeStyle.Transient))
				.AddFacility<ControllerRegisterFacility>()
				.Register(AllTypes.Of<IController>()
				          	.FromAssemblyNamed("BlogSharp.Web").Configure(x => x.LifeStyle.Transient))
				.Register(Component.For<IExtendedControllerFactory>()
				          	.ImplementedBy<WindsorControllerFactory>())
				.Register(AllTypes.Of<IStartupInstaller>()
				          	.FromAssemblyNamed("BlogSharp.Core.Impl")
				          	.WithService.FirstInterface())
				.Register(AllTypes.Of<IHttpModule>()
				          	.FromAssemblyNamed("BlogSharp.Core.Impl"))
				.Register(Component.For<BlogContextProvider>()
				          	.ImplementedBy<WebBlogContextProvider>());
		}

		#endregion
	}
}