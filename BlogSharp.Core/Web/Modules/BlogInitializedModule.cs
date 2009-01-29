using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Persistence;

namespace BlogSharp.Core.Web.Modules
{
	public class BlogInitializedModule:IBlogSharpHttpModule
	{

		public BlogInitializedModule
			(HttpApplicationEventWrapper eventWrapper,
			IList<IDataInitializer> dataInitializers)
		{
			this.eventWrapper = eventWrapper;
			this.dataInitializers = dataInitializers;
		}

		private readonly HttpApplicationEventWrapper eventWrapper;
		private readonly IList<IDataInitializer> dataInitializers;

		#region IBlogSharpHttpModule Members

		public void Start()
		{
			eventWrapper.BeginRequest += new EventHandler(eventWrapper_BeginRequest);
			eventWrapper.EndRequest += new EventHandler(eventWrapper_EndRequest);
		}

		void eventWrapper_BeginRequest(object sender, EventArgs e)
		{
			foreach (var initializer in dataInitializers)
			{
				if(initializer.ShouldRun(BlogContext.Current.Blog))
				{
					initializer.Run(BlogContext.Current.Blog);
				}
			}
		}
		void eventWrapper_EndRequest(object sender, EventArgs e)
		{
			this.Stop();
		}


		public void Stop()
		{
			this.eventWrapper.BeginRequest -= eventWrapper_BeginRequest;
			this.eventWrapper.EndRequest -= eventWrapper_EndRequest;
		}

		#endregion
	}
}
