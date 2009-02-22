namespace BlogSharp.Db4o.Blog.Repositories
{
	using Db4objects.Db4o.Events;

	public class Db4oRepository
	{
		protected readonly IObjectContainerManager container;

		public Db4oRepository(IObjectContainerManager container)
		{
			this.container = container;
		}

		public void SaveObject(object obj)
		{
			try
			{
				container.GetContainer().Store(obj);
			}
			catch (EventException eventException)
			{
				throw eventException.InnerException;
			}
		}

		public void RemoveObject(object obj)
		{
			try
			{
				container.GetContainer().Delete(obj);
			}
			catch (EventException eventException)
			{
				throw eventException.InnerException;
			}
		}
	}
}