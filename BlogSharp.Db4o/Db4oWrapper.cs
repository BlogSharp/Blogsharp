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
			inner.Activate(obj);
		}

		public void Backup(string path)
		{
			inner.Backup(path);
		}

		public void Bind(object obj, long id)
		{
			inner.Bind(obj, id);
		}

		public Db4objects.Db4o.Types.IDb4oCollections Collections()
		{
			return inner.Collections();
		}

		public Db4objects.Db4o.Config.IConfiguration Configure()
		{
			return inner.Configure();
		}

		public void Deactivate(object obj)
		{
			inner.Deactivate(obj);
		}

		public object Descend(object obj, string[] path)
		{
			return inner.Descend(obj, path);
		}

		public object GetByID(long id)
		{
			return inner.GetByID(id);
		}

		public object GetByUUID(Db4oUUID uuid)
		{
			return inner.GetByUUID(uuid);
		}

		public long GetID(object obj)
		{
			return inner.GetID(obj);
		}

		public IObjectInfo GetObjectInfo(object obj)
		{
			return inner.GetObjectInfo(obj);
		}

		public Db4oDatabase Identity()
		{
			return inner.Identity();
		}

		public bool IsActive(object obj)
		{
			return inner.IsActive(obj);
		}

		public bool IsCached(long id)
		{
			return inner.IsCached(id);
		}

		public bool IsClosed()
		{
			return inner.IsClosed();
		}

		public bool IsStored(object obj)
		{
			return inner.IsStored(obj);
		}

		public Db4objects.Db4o.Reflect.IReflectClass[] KnownClasses()
		{
			return inner.KnownClasses();
		}

		public object Lock()
		{
			return inner.Lock();
		}

		public object PeekPersisted(object @object, int depth, bool committed)
		{
			return inner.PeekPersisted(@object, depth, committed);
		}

		public void Purge(object obj)
		{
			inner.Purge(obj);
		}

		public void Purge()
		{
			inner.Purge();
		}

		public Db4objects.Db4o.Reflect.Generic.GenericReflector Reflector()
		{
			return inner.Reflector();
		}

		public void Refresh(object obj, int depth)
		{
			inner.Refresh(obj, depth);
		}

		public void ReleaseSemaphore(string name)
		{
			inner.ReleaseSemaphore(name);
		}

		public Db4objects.Db4o.Replication.IReplicationProcess ReplicationBegin(Db4objects.Db4o.IObjectContainer peerB,
		                                                                        Db4objects.Db4o.Replication.
		                                                                        	IReplicationConflictHandler conflictHandler)
		{
			return inner.ReplicationBegin(peerB, conflictHandler);
		}

		public void Set(object obj, int depth)
		{
			inner.Set(obj, depth);
		}

		public bool SetSemaphore(string name, int waitForAvailability)
		{
			return inner.SetSemaphore(name, waitForAvailability);
		}

		public void Store(object obj, int depth)
		{
			inner.Store(obj, depth);
		}

		public IStoredClass StoredClass(object clazz)
		{
			return inner.StoredClass(clazz);
		}

		public IStoredClass[] StoredClasses()
		{
			return inner.StoredClasses();
		}

		public ISystemInfo SystemInfo()
		{
			return inner.SystemInfo();
		}

		public long Version()
		{
			return inner.Version();
		}

		public void Activate(object obj, int depth)
		{
			inner.Activate(obj, depth);
		}

		public bool Close()
		{
			return inner.Close();
		}

		public void Commit()
		{
			inner.Commit();
		}

		public void Deactivate(object obj, int depth)
		{
			inner.Deactivate(obj, depth);
		}

		public void Delete(object obj)
		{
			inner.Delete(obj);
		}

		public IExtObjectContainer Ext()
		{
			return this;
		}

		public Db4objects.Db4o.IObjectSet Get(object template)
		{
			return inner.QueryByExample(template);
		}

		public IList<Extent> Query<Extent>(IComparer<Extent> comparer)
		{
			return inner.Query(comparer);
		}

		public IList<Extent> Query<Extent>()
		{
			return inner.Query<Extent>();
		}

		public IList<ElementType> Query<ElementType>(Type extent)
		{
			return inner.Query<ElementType>(extent);
		}

		public IList<Extent> Query<Extent>(Predicate<Extent> match, Comparison<Extent> comparison)
		{
			return inner.Query(match, comparison);
		}

		public IList<Extent> Query<Extent>(Predicate<Extent> match, IComparer<Extent> comparer)
		{
			return inner.Query(match, comparer);
		}

		public IList<Extent> Query<Extent>(Predicate<Extent> match)
		{
			return inner.Query(match);
		}

		public Db4objects.Db4o.IObjectSet Query(Db4objects.Db4o.Query.Predicate predicate,
		                                        System.Collections.IComparer comparer)
		{
			return inner.Query(predicate, comparer);
		}


		public Db4objects.Db4o.IObjectSet Query(Db4objects.Db4o.Query.Predicate predicate,
		                                        Db4objects.Db4o.Query.IQueryComparator comparator)
		{
			return inner.Query(predicate, comparator);
		}

		public Db4objects.Db4o.IObjectSet Query(Db4objects.Db4o.Query.Predicate predicate)
		{
			return inner.Query(predicate);
		}

		public Db4objects.Db4o.IObjectSet Query(Type clazz)
		{
			return inner.Query(clazz);
		}

		public Db4objects.Db4o.Query.IQuery Query()
		{
			return inner.Query();
		}

		public Db4objects.Db4o.IObjectSet QueryByExample(object template)
		{
			return inner.QueryByExample(template);
		}

		public void Rollback()
		{
			inner.Rollback();
		}

		public void Set(object obj)
		{
			inner.Store(obj);
		}

		public void Store(object obj)
		{
			inner.Store(obj);
		}

		public void Dispose()
		{
			inner.Dispose();
		}

		#endregion
	}
}