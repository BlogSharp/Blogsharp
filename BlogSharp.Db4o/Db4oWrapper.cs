namespace BlogSharp.Db4o
{
	using System;
	using System.Collections.Generic;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;

	public class Db4oWrapper : IExtObjectContainer, IObjectContainer
	{
		internal readonly IExtObjectContainer inner;

		public Db4oWrapper(IExtObjectContainer inner)
		{
			this.inner = inner;
		}

		#region IExtObjectContainer Members

		public void Activate(object obj)
		{
			this.inner.Activate(obj);
		}

		public void Backup(string path)
		{
			this.inner.Backup(path);
		}

		public void Bind(object obj, long id)
		{
			this.inner.Bind(obj, id);
		}

		public Db4objects.Db4o.Types.IDb4oCollections Collections()
		{
			return this.inner.Collections();
		}

		public Db4objects.Db4o.Config.IConfiguration Configure()
		{
			return this.inner.Configure();
		}

		public void Deactivate(object obj)
		{
			this.inner.Deactivate(obj);
		}

		public object Descend(object obj, string[] path)
		{
			return this.inner.Descend(obj, path);
		}

		public object GetByID(long id)
		{
			return this.inner.GetByID(id);
		}

		public object GetByUUID(Db4oUUID uuid)
		{
			return this.inner.GetByUUID(uuid);
		}

		public long GetID(object obj)
		{
			return this.inner.GetID(obj);
		}

		public IObjectInfo GetObjectInfo(object obj)
		{
			return this.inner.GetObjectInfo(obj);
		}

		public Db4oDatabase Identity()
		{
			return this.inner.Identity();
		}

		public bool IsActive(object obj)
		{
			return this.inner.IsActive(obj);
		}

		public bool IsCached(long id)
		{
			return this.inner.IsCached(id);
		}

		public bool IsClosed()
		{
			return this.inner.IsClosed();
		}

		public bool IsStored(object obj)
		{
			return this.inner.IsStored(obj);
		}

		public Db4objects.Db4o.Reflect.IReflectClass[] KnownClasses()
		{
			return this.inner.KnownClasses();
		}

		public object Lock()
		{
			return this.inner.Lock();
		}

		public object PeekPersisted(object @object, int depth, bool committed)
		{
			return this.inner.PeekPersisted(@object, depth, committed);
		}

		public void Purge(object obj)
		{
			this.inner.Purge(obj);
		}

		public void Purge()
		{
			this.inner.Purge();
		}

		public Db4objects.Db4o.Reflect.Generic.GenericReflector Reflector()
		{
			return this.inner.Reflector();
		}

		public void Refresh(object obj, int depth)
		{
			this.inner.Refresh(obj, depth);
		}

		public void ReleaseSemaphore(string name)
		{
			this.inner.ReleaseSemaphore(name);
		}

		public Db4objects.Db4o.Replication.IReplicationProcess ReplicationBegin(Db4objects.Db4o.IObjectContainer peerB,
		                                                                        Db4objects.Db4o.Replication.
		                                                                        	IReplicationConflictHandler conflictHandler)
		{
			return this.inner.ReplicationBegin(peerB, conflictHandler);
		}

		public void Set(object obj, int depth)
		{
			this.inner.Set(obj, depth);
		}

		public bool SetSemaphore(string name, int waitForAvailability)
		{
			return this.inner.SetSemaphore(name, waitForAvailability);
		}

		public void Store(object obj, int depth)
		{
			this.inner.Store(obj, depth);
		}

		public IStoredClass StoredClass(object clazz)
		{
			return this.inner.StoredClass(clazz);
		}

		public IStoredClass[] StoredClasses()
		{
			return this.inner.StoredClasses();
		}

		public ISystemInfo SystemInfo()
		{
			return this.inner.SystemInfo();
		}

		public long Version()
		{
			return this.inner.Version();
		}

		public void Activate(object obj, int depth)
		{
			this.inner.Activate(obj, depth);
		}

		public bool Close()
		{
			return this.inner.Close();
		}

		public void Commit()
		{
			this.inner.Commit();
		}

		public void Deactivate(object obj, int depth)
		{
			this.inner.Deactivate(obj, depth);
		}

		public void Delete(object obj)
		{
			this.inner.Delete(obj);
		}

		public IExtObjectContainer Ext()
		{
			return this;
		}

		public Db4objects.Db4o.IObjectSet Get(object template)
		{
			return this.inner.QueryByExample(template);
		}

		public IList<Extent> Query<Extent>(IComparer<Extent> comparer)
		{
			return this.inner.Query(comparer);
		}

		public IList<Extent> Query<Extent>()
		{
			return this.inner.Query<Extent>();
		}

		public IList<ElementType> Query<ElementType>(Type extent)
		{
			return this.inner.Query<ElementType>(extent);
		}

		public IList<Extent> Query<Extent>(Predicate<Extent> match, Comparison<Extent> comparison)
		{
			return this.inner.Query(match, comparison);
		}

		public IList<Extent> Query<Extent>(Predicate<Extent> match, IComparer<Extent> comparer)
		{
			return this.inner.Query(match, comparer);
		}

		public IList<Extent> Query<Extent>(Predicate<Extent> match)
		{
			return this.inner.Query(match);
		}

		public Db4objects.Db4o.IObjectSet Query(Db4objects.Db4o.Query.Predicate predicate,
		                                        System.Collections.IComparer comparer)
		{
			return this.inner.Query(predicate, comparer);
		}


		public Db4objects.Db4o.IObjectSet Query(Db4objects.Db4o.Query.Predicate predicate,
		                                        Db4objects.Db4o.Query.IQueryComparator comparator)
		{
			return this.inner.Query(predicate, comparator);
		}

		public Db4objects.Db4o.IObjectSet Query(Db4objects.Db4o.Query.Predicate predicate)
		{
			return this.inner.Query(predicate);
		}

		public Db4objects.Db4o.IObjectSet Query(Type clazz)
		{
			return this.inner.Query(clazz);
		}

		public Db4objects.Db4o.Query.IQuery Query()
		{
			return this.inner.Query();
		}

		public Db4objects.Db4o.IObjectSet QueryByExample(object template)
		{
			return this.inner.QueryByExample(template);
		}

		public void Rollback()
		{
			this.inner.Rollback();
		}

		public void Set(object obj)
		{
			this.inner.Store(obj);
		}

		public void Store(object obj)
		{
			this.inner.Store(obj);
		}

		public void Dispose()
		{
			this.inner.Dispose();
		}

		#endregion
	}
}