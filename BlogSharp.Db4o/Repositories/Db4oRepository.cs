using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSharp.Model;
using Db4objects.Db4o;
namespace BlogSharp.Db4o.Repositories
{
    public class Db4oRepository
    {
		public Db4oRepository(IObjectContainerManager container)
        {
            this.container = container;
        }

		protected readonly IObjectContainerManager container;
        
        public void SaveObject(object obj)
        {
            container.GetContainer().Store(obj);
        }

        public void RemoveObject(object obj)
        {
			container.GetContainer().Delete(obj);
        }

    }
}
