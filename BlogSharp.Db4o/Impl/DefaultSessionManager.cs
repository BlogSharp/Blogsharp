namespace BlogSharp.Db4o.Impl
{
	using System;
	using System.Transactions;
	using Castle.MicroKernel;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;

	/// This piece has been taken from Castle Project (http://castleproject.org)
	public class DefaultSessionManager : IObjectContainerManager
	{
		private const string ContainerContextKey = "containers";
		private readonly IKernel container;
		private readonly IObjectContainerProviderProvider provider;
		private readonly IObjectContainerStore store;

		public DefaultSessionManager(
			IKernel container,
			IObjectContainerStore store,
			IObjectContainerProviderProvider provider,
			IObjectContainerWrapper wrapper)
		{
			this.container = container;
			this.provider = provider;
			this.Wrapper = wrapper;
			this.store = store;
		}

		protected IObjectContainerWrapper Wrapper { get; private set; }

		#region IObjectContainerManager Members

		public IObjectContainer GetContainer(string alias)
		{
			if (alias == null)
				throw new ArgumentNullException("alias");

			bool weAreSessionOwner = false;

			IExtObjectContainer wrapped = this.store[alias];
			IExtObjectContainer session;

			if (wrapped == null)
			{
				var initializers = this.container.ResolveAll<IDb4oInitializationHandler>();
				session = this.CreateObjectContainer(alias);
				foreach (var handler in initializers)
				{
					handler.HandleObjectContainerCreated(session);
				}
				weAreSessionOwner = true;
				wrapped = this.WrapSession(Transaction.Current != null, session);

				this.EnlistIfNecessary(weAreSessionOwner, wrapped);
				this.store[alias] = wrapped;
			}
			else
			{
				this.EnlistIfNecessary(weAreSessionOwner, wrapped);
				IObjectContainerProxy proxy = wrapped as IObjectContainerProxy;
				wrapped = this.WrapSession(true, this.Wrapper.UnWrap(wrapped));
			}

			return wrapped;
		}

		public virtual IObjectContainer GetContainer()
		{
			return this.GetContainer(Constants.DefaultAlias);
		}

		#endregion

		protected virtual IExtObjectContainer WrapSession(bool hasTransaction, IExtObjectContainer container)
		{
			IExtObjectContainer wrapped = this.Wrapper.Wrap(container, null, null);
			return wrapped;
		}

		protected virtual IExtObjectContainer CreateObjectContainer(string alias)
		{
			IObjectContainerProvider containerProvider = this.provider.GetFactory(alias);
			return containerProvider.GetContainer();
		}


		protected virtual bool EnlistIfNecessary(bool weAreSessionOwner,
		                                         IExtObjectContainer container)
		{
			if (Transaction.Current == null)
				return false;
			var transaction = Transaction.Current;
			transaction.EnlistVolatile(new ResourceObjectContainerAdapter(container), EnlistmentOptions.None);

			return true;
		}
	}
}