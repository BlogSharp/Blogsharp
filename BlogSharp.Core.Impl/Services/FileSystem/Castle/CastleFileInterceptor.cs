using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	public class CastleFileInterceptor:IInterceptor
	{
		public CastleFileInterceptor(IFileService fileService)
		{
			this.fileService = fileService;
		}

		protected readonly IFileService fileService;
		public virtual void Intercept(IInvocation invocation)
		{
			if(invocation.Method.Name.Equals("get_Parent"))
			{
				IDirectory dir = invocation.InvocationTarget as IDirectory;
				string current = dir.Path;
				string parent = new DirectoryInfo(current).Parent.FullName;
				if (parentDirectory == null)
				{
					this.parentDirectory = fileService.GetDirectory(parent);
				}
					
				invocation.ReturnValue = this.parentDirectory;
			}
			else
				invocation.Proceed();
		}

		private IDirectory parentDirectory;
	}
}
