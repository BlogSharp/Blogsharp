namespace BlogSharp.Db4o
{
	using System;
	using System.Collections.Generic;
	using System.Web;
	using Core.Web.Modules;
	using Db4objects.Db4o.Ext;
	using Impl;

	public class Db4oHttpModule : IBlogSharpHttpModule
	{
		#region IBlogSharpHttpModule Members

		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.EndRequest += this.HandleEndRequest;
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