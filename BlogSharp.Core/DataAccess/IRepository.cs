using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
	public interface IRepository<T> where T:IIdentifiable<int>
	{
		void Add(T obj);
		void Remove(T obj);
		T GetById(int id);
		IEnumerable<T> GetByExpression(Expression<Func<T,bool>> predicate);
		IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> order);
	}
}
