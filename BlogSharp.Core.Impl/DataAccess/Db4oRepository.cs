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
    public class Db4oRepository
    {
        public Db4oRepository(IObjectContainer container)
        {
            this.container = container;
        }

        protected readonly IObjectContainer container;
        
        public void SaveObject(object obj)
        {
            container.Store(obj);
        }

        public void RemoveObject(object obj)
        {
            container.Delete(obj);
        }

    }
}
