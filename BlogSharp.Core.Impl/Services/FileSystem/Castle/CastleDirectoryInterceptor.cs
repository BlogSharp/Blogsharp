using System.Collections.Generic;
using BlogSharp.Core.Services.FileSystem;
using Castle.Core.Interceptor;

namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	public class CastleDirectoryInterceptor : CastleFileInterceptor
	{
		private IEnumerable<IFileSystemInfo> collection;

		public CastleDirectoryInterceptor(IFileService fileService) : base(fileService)
		{
		}

		public override void Intercept(IInvocation invocation)
		{
			if (invocation.Method.Name.Equals("get_Children"))
			{
				if (collection == null)
				{
					IDirectory dir = invocation.InvocationTarget as IDirectory;
					collection = base.fileService.SearchDirectory(dir.Path, "*.*", SearchOptions.Both, SearchLocation.TopDirectory);
				}
				invocation.ReturnValue = collection;
			}
			else
				base.Intercept(invocation);
		}
	}
}