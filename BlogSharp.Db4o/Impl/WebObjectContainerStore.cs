﻿using System.Collections.Generic;
using System.Web;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Impl
{
	public class WebObjectContainerStore : IObjectContainerStore
	{
		public const string CONTEXTKEY = "objectcontainers";

		#region IObjectContainerStore Members

		public virtual IDictionary<string, IExtObjectContainer> Dictionary
		{
			get
			{
				if (!HttpContext.Current.Items.Contains(CONTEXTKEY))
					HttpContext.Current.Items[CONTEXTKEY] = new Dictionary<string, IExtObjectContainer>();
				return HttpContext.Current.Items[CONTEXTKEY] as IDictionary<string, IExtObjectContainer>;
			}
		}

		public IExtObjectContainer this[string alias]
		{
			get
			{
				IExtObjectContainer container;
				Dictionary.TryGetValue(alias, out container);
				return container;
			}
			set { Dictionary[alias] = value; }
		}

		#endregion
	}
}