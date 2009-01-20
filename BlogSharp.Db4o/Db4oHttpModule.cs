using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;

namespace BlogSharp.Db4o
{
	public class Db4oHttpModule
	{
		public Db4oHttpModule(HttpApplication application,IDictionary<string,IObjectContainerProvider> providers)
		{
			this.providers = providers;
			this.application = application;
			this.application.BeginRequest+=HandleBeginRequest;
			this.application.EndRequest+=HandleEndRequest;
		}

		private readonly HttpApplication application;
		private readonly IDictionary<string, IObjectContainerProvider> providers;

		public void HandleBeginRequest(object sender, EventArgs ea)
		{
			foreach (var pair in providers)
			{
				HttpContext.Current.Items[pair.Key] = pair.Value.GetContainer();
			}
		}

		public void HandleEndRequest(object sender,EventArgs ea)
		{
			foreach (var pair in providers)
			{
				((IObjectContainer)HttpContext.Current.Items[pair.Key]).Commit();
				((IObjectContainer) HttpContext.Current.Items[pair.Key]).Close();
			}
		}
	}
}
