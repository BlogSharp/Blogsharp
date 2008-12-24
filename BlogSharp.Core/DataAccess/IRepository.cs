using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IRepository<T> where T : IIdentifiable<int>
    {
        void Save(T obj);
        void Delete(T obj);
        T GetById(int id);
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> order);
    }
}
