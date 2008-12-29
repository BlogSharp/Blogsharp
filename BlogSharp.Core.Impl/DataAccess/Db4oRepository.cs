using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSharp.CastleExtensions.Facilities.Db4o;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
namespace BlogSharp.Core.Impl.DataAccess
{
    public class Db4oRepository
    {
        public Db4oRepository(ISessionManager session)
        {
            //this.container = container;
        	this.session = session;
        }

        protected IObjectContainer container;
    	protected readonly ISessionManager session;
        
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
