using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core;
using Castle.MicroKernel;

namespace BlogSharp.Core.CastleExtensions.DependencyResolvers
{
	public class ListResolver : ISubDependencyResolver
	{
		private readonly IKernel kernel;

		public ListResolver(IKernel kernel)
		{
			this.kernel = kernel;
		}

		#region ISubDependencyResolver Members

		public object Resolve(CreationContext context, ISubDependencyResolver parentResolver,
							  ComponentModel model,
							  DependencyModel dependency)
		{
			Type t = dependency.TargetType.GetGenericArguments()[0];
			return kernel.ResolveAll(t, null);
		}

		public bool CanResolve(CreationContext context, ISubDependencyResolver parentResolver,
							   ComponentModel model,
							   DependencyModel dependency)
		{
			bool result = dependency.TargetType != null &&
							dependency.TargetType.GetGenericArguments().Length!=0&&
			              typeof (IList<>).MakeGenericType(dependency.TargetType.GetGenericArguments()[0]).IsAssignableFrom(dependency.TargetType);
			return result;
		}

		#endregion
	}
}
