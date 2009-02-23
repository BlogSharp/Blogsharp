namespace BlogSharp.Db4o
{
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;

	/// <summary>
	/// The general contract between a class that generates unique
	/// identifiers and the <see cref="IObjectContainer"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Implementors should provide a public default constructor.
	/// </para>
	/// <para>
	/// Implementors <b>must</b> be threadsafe.
	/// </para>
	/// </remarks>
	public interface IIdentifierGenerator
	{
		object Generate(IExtObjectContainer container, object obj);
	}
}
