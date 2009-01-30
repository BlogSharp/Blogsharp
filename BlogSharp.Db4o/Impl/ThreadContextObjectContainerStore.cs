﻿using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Impl
{
	public class ThreadContextObjectContainerStore : IObjectContainerStore
	{
		public const string CONTEXTKEY = "objectcontainers";

		#region IObjectContainerStore Members

		public virtual IDictionary<string, IExtObjectContainer> Dictionary
		{
			get
			{
				if (CallContext.GetData(CONTEXTKEY) as IDictionary<string, IExtObjectContainer> == null)
					CallContext.SetData(CONTEXTKEY, new Dictionary<string, IExtObjectContainer>());
				return CallContext.GetData(CONTEXTKEY) as IDictionary<string, IExtObjectContainer>;
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