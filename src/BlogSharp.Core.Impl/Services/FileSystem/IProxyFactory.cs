namespace BlogSharp.Core.Impl.Services.FileSystem
{
	using Core.Services.FileSystem;
	using Native;

	public interface IProxyFactory
	{
		IFile CreateFileWithProxy(IFileService fileService, string fileName, NativeMethods.WIN32_FIND_DATA findData);
		IDirectory CreateDirectoryWithProxy(IFileService fileService, string fileName);
	}
}