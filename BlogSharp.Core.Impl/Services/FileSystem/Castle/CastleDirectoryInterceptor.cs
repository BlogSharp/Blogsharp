using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;
using Castle.Core.Interceptor;

namespace BlogSharp.Core.Impl.Services.FileSystem.Castle
{
	public class CastleDirectoryInterceptor:CastleFileInterceptor
	{
		public CastleDirectoryInterceptor(IFileService fileService):base(fileService)
		{

		}
		public override void Intercept(IInvocation invocation)
		{
			if (invocation.Method.Name.Equals("get_Children"))
			{
				if(collection==null)
				{
					IDirectory dir = invocation.InvocationTarget as IDirectory;
					collection=base.fileService.SearchDirectory(dir.Path, "*.*",SearchOptions.Both,SearchLocation.TopDirectory);
				}
				invocation.ReturnValue = collection;
			}
			else
				base.Intercept(invocation);
		}

		private IEnumerable<IFileSystemInfo> collection;
	}
}
