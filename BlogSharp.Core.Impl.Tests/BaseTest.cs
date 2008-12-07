using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Rhino.Mocks;

namespace BlogSharp.Core.Impl.Tests
{
	public class BaseTest:IDisposable
	{
		protected virtual IEntityFactory<T> GetEntityFactory<T>() where T:class
		{
	
			var mock=MockRepository.GenerateStub<IEntityFactory<T>>();
			mock.Expect(x => x.Create()).Return(MockRepository.GenerateStub<T>());
			return mock;
		}

		public virtual void OnTearDown()
		{
			
		}
		#region IDisposable Members

		public void Dispose()
		{
			this.OnTearDown();
		}

		#endregion
	}
}
