namespace BlogSharp.Db4o.Tests
{
	using Db4objects.Db4o;

	public class TestObjectContainerManager : IObjectContainerManager
	{
		private readonly IObjectContainer objectContainer;

		public TestObjectContainerManager(IObjectContainer objectContainer)
		{
			this.objectContainer = objectContainer;
		}

		#region IObjectContainerManager Members

		public Db4objects.Db4o.IObjectContainer GetContainer()
		{
			return this.objectContainer;
		}

		public Db4objects.Db4o.IObjectContainer GetContainer(string alias)
		{
			return this.objectContainer;
		}

		#endregion
	}
}