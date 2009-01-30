namespace BlogSharp.Db4o.Repositories
{
	public class Db4oRepository
	{
		protected readonly IObjectContainerManager container;

		public Db4oRepository(IObjectContainerManager container)
		{
			this.container = container;
		}

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