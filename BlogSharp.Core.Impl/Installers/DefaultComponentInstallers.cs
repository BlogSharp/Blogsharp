using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BlogSharp.Core.Event;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Impl.Services.Mail;
using BlogSharp.Core.Impl.Services.Post;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Post;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BlogSharp.Core.Impl.Installers
{
	public class DefaultComponentInstallers:IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, Castle.MicroKernel.IConfigurationStore store)
		{
			container.Register(Component.For<IPostService>().ImplementedBy<PostService>());
			container.Register(Component.For<IMailService>().ImplementedBy<MailService>());
		}

		#endregion
	}
}
