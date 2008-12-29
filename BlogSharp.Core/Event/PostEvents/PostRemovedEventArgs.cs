using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostRemovedEventArgs:AbstractEventArgs
	{
		public PostRemovedEventArgs(IPost post)
		{
			this.Post = post;
		}

		public IPost Post { get; private set; }
	}
}
