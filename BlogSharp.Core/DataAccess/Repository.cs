using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
	public static class Repository<T> where T:IIdentifiable<int>
	{
		public static IRepository<T> Instance
		{	
			get
			{
				return DI.Container.Resolve<IRepository<T>>();
			}
		}

	}
}
