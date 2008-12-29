using Db4objects.Db4o;

namespace BlogSharp.CastleExtensions.Facilities.Db4o
{
	public interface ISessionManager
	{
		IObjectContainer OpenFile();
		IObjectContainer OpenFile(string filename);
	}
}
