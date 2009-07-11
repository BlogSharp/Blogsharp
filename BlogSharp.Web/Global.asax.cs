namespace BlogSharp.Web
{
	using System;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using Castle.Windsor;
	using CastleExtensions.DependencyResolvers;
	using Controllers;
	using Core.Impl.Installers;
	using Core.Impl.Web;
	using Core.Web.Modules;
	using MvcContrib.Routing;
	using MvcExtensions;
	using Spark.Web.Mvc;

	public class MvcApplication : HttpApplication, IContainerAccessor
	{
		private static IWindsorContainer container;

		#region IContainerAccessor Members

		public IWindsorContainer Container
		{
			get { return container; }
		}

		#endregion

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.RouteExistingFiles = false;
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{resource}.ico");

			MvcRoute.MappUrl("post/list/{page}")
				.ToDefaultAction<PostController>(x => x.List(1))
				.AddWithName("PostList", routes);
			MvcRoute.MappUrl("post/read/{friendlyTitle}")
				.ToDefaultAction<PostController>(x => x.Read("friendlyTitle"))
				.AddWithName("PostRead", routes);
			MvcRoute.MappUrl("post/addcomment")
				.ToDefaultAction<PostController>(x => x.AddComment(0, null))
				.AddWithName("PostCommentAdd", routes);
			MvcRoute.MappUrl("tag/{tagName}")
				.ToDefaultAction<PostController>(x => x.ListByTag("", 1))
				.AddWithName("PostListByTag", routes);
			MvcRoute.MappUrl("{controller}/{action}")
				.ToDefaultAction<PostController>(x => x.List(1))
				.AddWithName("Default", routes);
		}


		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
			try
			{
				var engine = new SparkViewFactory();
				container = new WindsorContainer("Configuration/castle.xml");
				ViewEngines.Engines.Add(engine);
			}
			catch(Exception exception)
			{
			}
			container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
			container.Install(new DefaultComponentInstallers());
			ControllerBuilder.Current.SetControllerFactory(container.Resolve<IExtendedControllerFactory>());
			BlogContextProvider.Current = container.Resolve<BlogContextProvider>();
		}

		public override void Init()
		{
			var modules = container.ResolveAll<IBlogSharpHttpModule>();
			foreach (var module in modules)
			{
				module.Init(this);
			}
		}
	}
}