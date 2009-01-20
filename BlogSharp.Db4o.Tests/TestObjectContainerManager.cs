using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace BlogSharp.Db4o.Tests
{
	public class TestObjectContainerManager:IObjectContainerManager
	{
		public TestObjectContainerManager(IObjectContainer objectContainer)
		{
			this.objectContainer = objectContainer;
		}

		private readonly IObjectContainer objectContainer;
		#region IObjectContainerManager Members

		public Db4objects.Db4o.IObjectContainer GetContainer()
		{
			return objectContainer;
		}

		public Db4objects.Db4o.IObjectContainer GetContainer(string alias)
		{
			return objectContainer;
		}

		#endregion
	}
}
