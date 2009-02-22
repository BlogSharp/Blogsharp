namespace BlogSharp.Db4o
{
	using System.Transactions;
	using Db4objects.Db4o;

	public class ResourceObjectContainerAdapter : IEnlistmentNotification
	{
		private readonly IObjectContainer objectContainer;

		public ResourceObjectContainerAdapter(IObjectContainer objectContainer)
		{
			this.objectContainer = objectContainer;
		}

		#region IEnlistmentNotification Members

		public void Commit(Enlistment enlistment)
		{
			this.objectContainer.Commit();
		}

		public void InDoubt(Enlistment enlistment)
		{
		}

		public void Prepare(PreparingEnlistment preparingEnlistment)
		{
			preparingEnlistment.Prepared();
		}

		public void Rollback(Enlistment enlistment)
		{
			this.objectContainer.Rollback();
		}

		#endregion
	}
}