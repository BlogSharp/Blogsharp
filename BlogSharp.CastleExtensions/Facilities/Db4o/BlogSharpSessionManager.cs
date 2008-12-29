using System;
using System.IO;
using Db4objects.Db4o;

namespace BlogSharp.CastleExtensions.Facilities.Db4o
{
	public class BlogSharpSessionManager : ISessionManager
	{
		private const string defaultFilename = "blogsharp.db4o";

		public IObjectContainer OpenFile()
		{
			return OpenFile(defaultFilename);
		}

		public IObjectContainer OpenFile(string filename)
		{
			return Db4oFactory.OpenFile(MapPath(filename));
		}

		/// <summary>
		/// Lets MapPath fonctionality into the class library.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		protected static string MapPath(string path)
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
		}
	}
}
