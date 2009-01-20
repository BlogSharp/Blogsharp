using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Services.Transaction;
using Db4objects.Db4o;

namespace BlogSharp.Db4o
{
	public class ResourceObjectContainerAdapter : IResource
	{
		private readonly IObjectContainer objectContainer;

		public ResourceObjectContainerAdapter(IObjectContainer objectContainer)
		{
			this.objectContainer = objectContainer;
		}

		public void Start()
		{
		}

		public void Commit()
		{
			objectContainer.Commit();
		}

		public void Rollback()
		{
			objectContainer.Rollback();
		}
	}
}
