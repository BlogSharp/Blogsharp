namespace BlogSharp.Db4o
{
	using System.Collections.Generic;
	using Db4objects.Db4o.Ext;

	public interface IObjectContainerStore
	{
		IExtObjectContainer this[string alias] { get; set; }
		IDictionary<string, IExtObjectContainer> Dictionary { get; }
	}
}