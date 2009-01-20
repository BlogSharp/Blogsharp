using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Impl
{
	public class ThreadContextObjectContainerStore:IObjectContainerStore
	{
		public const string CONTEXTKEY = "objectcontainers";
		
		public virtual IDictionary<string, IExtObjectContainer> Dictionary
		{
			get
			{

				if(CallContext.GetData(CONTEXTKEY) as IDictionary<string, IExtObjectContainer> == null)
					CallContext.SetData(CONTEXTKEY,new Dictionary<string,IExtObjectContainer>());
				return CallContext.GetData(CONTEXTKEY) as IDictionary<string, IExtObjectContainer>;
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
