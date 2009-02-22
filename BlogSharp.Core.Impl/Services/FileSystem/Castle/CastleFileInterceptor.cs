namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	using System.IO;
	using Core.Services.FileSystem;
	using global::Castle.Core.Interceptor;

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
				if (this.parentDirectory == null)
				{
					this.parentDirectory = this.fileService.GetDirectory(parent);
				}

				invocation.ReturnValue = this.parentDirectory;
			}
			else
				invocation.Proceed();
		}

		#endregion
	}
}