using BlogSharp.Core.Impl.Services.FileSystem.Native;
using BlogSharp.Core.Services.FileSystem;
using Castle.DynamicProxy;

namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	public class CastleProxyFactory : IProxyFactory
	{
		private readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

		#region IProxyFactory Members

		public IFile CreateFileWithProxy(IFileService fileService, string fileName, NativeMethods.WIN32_FIND_DATA findData)
		{
			return proxyGenerator.CreateInterfaceProxyWithTarget<IFile>(new File(fileName, findData),
			                                                            new CastleFileInterceptor(fileService));
		}

		public IDirectory CreateDirectoryWithProxy(IFileService fileService, string fileName)
		{
			return proxyGenerator.CreateInterfaceProxyWithTarget<IDirectory>(new Directory(fileName),
			                                                                 new CastleDirectoryInterceptor(fileService));
		}

		#endregion
	}
}