using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl
{
	public class DIEntityFactory<T>:IEntityFactory<T>
	{
		#region IEntityFactory<T> Members

		public T Create()
		{
			return DI.Container.Resolve<T>();
		}

		#endregion
	}
}
