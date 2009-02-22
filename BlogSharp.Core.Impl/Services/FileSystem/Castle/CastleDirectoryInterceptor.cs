namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	using System.Collections.Generic;
	using Core.Services.FileSystem;
	using global::Castle.Core.Interceptor;

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
				if (this.collection == null)
				{
					IDirectory dir = invocation.InvocationTarget as IDirectory;
					this.collection = base.fileService.SearchDirectory(dir.Path, "*.*", SearchOptions.Both, SearchLocation.TopDirectory);
				}
				invocation.ReturnValue = this.collection;
			}
			else
				base.Intercept(invocation);
		}
	}
}