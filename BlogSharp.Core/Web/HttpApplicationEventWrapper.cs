using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogSharp.Core.Web
{
    //Add events on demand
	public class HttpApplicationEventWrapper
	{
		public HttpApplicationEventWrapper(HttpApplication app)
		{
			app.BeginRequest += app_BeginRequest;
			app.EndRequest += app_EndRequest;
		}

		public event EventHandler BeginRequest=delegate { };
		public event EventHandler EndRequest=delegate { };

		void app_EndRequest(object sender, EventArgs e)
		{
			this.EndRequest(sender, e);
		}

		void app_BeginRequest(object sender, EventArgs e)
		{
			this.BeginRequest(sender, e);
		}

	}
}
