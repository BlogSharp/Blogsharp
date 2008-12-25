using System;
using System.IO;
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
        
        /// <summary>
        /// Lets MapPath fonctionality into the class library.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected static string MapPath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

		#region IDisposable Members

		public void Dispose()
		{
			OnTearDown();
		}

		#endregion
	}
}
