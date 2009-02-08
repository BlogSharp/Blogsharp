using System;
using System.Collections.Generic;
using BlogSharp.Db4o.Blog;
using Castle.MicroKernel;
using Castle.Services.Transaction;
using Castle.Windsor;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Impl
{
	/// This piece has been taken from Castle Project (http://castleproject.org)
	public class DefaultSessionManager : IObjectContainerManager
	{
		private const string ContainerContextKey = "containers";
		private readonly IKernel container;
		private readonly IObjectContainerProviderProvider provider;
		private readonly IObjectContainerStore store;
		private readonly ITransactionManager transactionManager;

		public DefaultSessionManager(
									 IKernel container,
									 IObjectContainerStore store,
									 ITransactionManager transactionManager,
									 IObjectContainerProviderProvider provider,
			IObjectContainerWrapper wrapper)
		{
			this.container = container;
			this.provider = provider;
			this.Wrapper = wrapper;
			this.transactionManager = transactionManager;
			this.store = store;
		}

		protected IObjectContainerWrapper Wrapper { get; private set; }

		#region IObjectContainerManager Members

		public IObjectContainer GetContainer(string alias)
		{
			if (alias == null)
				throw new ArgumentNullException("alias");

			ITransaction transaction = transactionManager.CurrentTransaction;

			bool weAreSessionOwner = false;

			IExtObjectContainer wrapped = store[alias];
			IExtObjectContainer session;

			if (wrapped == null)
			{
				var initializers = this.container.ResolveAll<IDb4oInitializationHandler>();
				session = CreateObjectContainer(alias);
				foreach (var handler in initializers)
				{
					handler.HandleObjectContainerCreated(session);
				}
				weAreSessionOwner = true;
				wrapped = WrapSession(transaction != null, session);

				EnlistIfNecessary(weAreSessionOwner, transaction, wrapped);
				store[alias] = wrapped;
			}
			else
			{
				EnlistIfNecessary(weAreSessionOwner, transaction, wrapped);
				IObjectContainerProxy proxy = wrapped as IObjectContainerProxy;
				wrapped = WrapSession(true, Wrapper.UnWrap(wrapped));
			}

			return wrapped;
		}

		public virtual IObjectContainer GetContainer()
		{
			return GetContainer(Constants.DefaultAlias);
		}

		#endregion

		protected virtual IExtObjectContainer WrapSession(bool hasTransaction, IExtObjectContainer container)
		{
			IExtObjectContainer wrapped = Wrapper.Wrap(container, null, null);
			return wrapped;
		}

		protected virtual IExtObjectContainer CreateObjectContainer(string alias)
		{
			IObjectContainerProvider containerProvider = provider.GetFactory(alias);
			return containerProvider.GetContainer();
		}


		protected virtual bool EnlistIfNecessary(bool weAreSessionOwner, ITransaction transaction,
												 IExtObjectContainer container)
		{
			if (transaction == null)
				return false;

			IList<IExtObjectContainer> list = (IList<IExtObjectContainer>)transaction.Context[ContainerContextKey];

			bool shouldEnlist;

			if (list == null)
			{
				list = new List<IExtObjectContainer>();
				shouldEnlist = true;
			}
			else
			{
				shouldEnlist = true;

				foreach (IExtObjectContainer cont in list)
				{
					if (ObjectContainerComparer.AreEqual(cont, container))
					{
						shouldEnlist = false;
						break;
					}
				}
			}

			if (shouldEnlist)
			{
				if (!transaction.DistributedTransaction)
				{
					transaction.Context[ContainerContextKey] = list;
					transaction.Enlist(new ResourceObjectContainerAdapter(container));

					list.Add(container);
				}

				if (weAreSessionOwner)
				{
					//transaction.RegisterSynchronization(new ContainerDisposeSynchronization(container));
				}
			}

			return true;
		}
	}
}