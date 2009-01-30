using System;
using System.Collections.Generic;
using System.Web;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o
{
	public class Db4oHttpModule : IHttpModule
	{
		#region IHttpModule Members

		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += HandleEndRequest;
		}

		#endregion

		public void HandleEndRequest(object sender, EventArgs ea)
		{
			var providers =
				(IDictionary<string, IExtObjectContainer>) HttpContext.Current.Items[WebObjectContainerStore.CONTEXTKEY];
			if (providers == null)
				return;
			foreach (var pair in providers)
			{
				pair.Value.Commit();
				pair.Value.Dispose();
			}
		}
	}
}