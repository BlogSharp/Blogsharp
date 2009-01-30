using System.IO;
using BlogSharp.Core.Services.FileSystem;
using Castle.Core.Interceptor;

namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	public class CastleFileInterceptor : IInterceptor
	{
		protected readonly IFileService fileService;

		private IDirectory parentDirectory;

		public CastleFileInterceptor(IFileService fileService)
		{
			this.fileService = fileService;
		}

		#region IInterceptor Members

		public virtual void Intercept(IInvocation invocation)
		{
			if (invocation.Method.Name.Equals("get_Parent"))
			{
				IDirectory dir = invocation.InvocationTarget as IDirectory;
				string current = dir.Path;
				string parent = new DirectoryInfo(current).Parent.FullName;
				if (parentDirectory == null)
				{
					parentDirectory = fileService.GetDirectory(parent);
				}

				invocation.ReturnValue = parentDirectory;
			}
			else
				invocation.Proceed();
		}

		#endregion
	}
}