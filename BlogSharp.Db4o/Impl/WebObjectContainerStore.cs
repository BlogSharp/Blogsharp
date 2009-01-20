using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Impl
{
	public class WebObjectContainerStore:IObjectContainerStore
	{
		public const string CONTEXTKEY = "objectcontainers";
		public virtual IDictionary<string, IExtObjectContainer> Dictionary
		{
			get
			{
				if (!HttpContext.Current.Items.Contains(CONTEXTKEY))
					HttpContext.Current.Items[CONTEXTKEY] = new Dictionary<string, IExtObjectContainer>();
				return HttpContext.Current.Items[CONTEXTKEY] as IDictionary<string, IExtObjectContainer>;
			}
		}

		#region IObjectContainerStore Members

		public IExtObjectContainer this[string alias]
		{
			get
			{
				IExtObjectContainer container;
				this.Dictionary.TryGetValue(alias, out container);
				return container;
			}
			set
			{
				this.Dictionary[alias] = value;
			}

		}

		#endregion
	}
}
