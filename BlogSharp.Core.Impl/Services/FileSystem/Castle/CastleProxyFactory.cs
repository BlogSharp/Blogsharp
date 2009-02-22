namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	using Core.Services.FileSystem;
	using global::Castle.DynamicProxy;
	using Native;

	public class CastleProxyFactory : IProxyFactory
	{
		private readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

		#region IProxyFactory Members

		public IFile CreateFileWithProxy(IFileService fileService, string fileName, NativeMethods.WIN32_FIND_DATA findData)
		{
			return this.proxyGenerator.CreateInterfaceProxyWithTarget<IFile>(new File(fileName, findData),
			                                                                 new CastleFileInterceptor(fileService));
		}

		public IDirectory CreateDirectoryWithProxy(IFileService fileService, string fileName)
		{
			return this.proxyGenerator.CreateInterfaceProxyWithTarget<IDirectory>(new Directory(fileName),
			                                                                      new CastleDirectoryInterceptor(fileService));
		}

		#endregion
	}
}