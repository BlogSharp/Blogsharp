using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
namespace BlogSharp.Core.Impl.DataAccess
{
	public class Db4oRepository<T>:IRepository<T> where T:IIdentifiable<int>
	{
		public Db4oRepository(IObjectContainer container)
		{
			this.container = container;
		}

		private readonly IObjectContainer container;
		#region IRepository<T> Members

		public void Add(T obj)
		{
			container.Store(obj);
		}

		public void Remove(T obj)
		{
			container.Delete(obj);
		}

		public T GetById(int id)
		{
			return container.Cast<T>().Where(x => x.Id == id).FirstOrDefault();
		}

		public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate)
		{
			return container.Cast<T>().Where(predicate);
		}

		public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate, System.Linq.Expressions.Expression<Func<T, int>> order)
		{
			return container.Cast<T>().Where(predicate).OrderBy(order);
		}

		#endregion
	}
}
