using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core;
using Castle.MicroKernel;

namespace BlogSharp.CastleExtensions.DependencyResolvers
{
	public class ServiceIdResolver : ISubDependencyResolver
	{
		#region ISubDependencyResolver Members
		public bool CanResolve(CreationContext context, ISubDependencyResolver parentResolver,
								ComponentModel model, DependencyModel dependency)
		{
			return dependency.DependencyKey.ToLowerInvariant().Equals("serviceid") &&
				   dependency.TargetType == typeof(string);

		}
		public object Resolve(CreationContext context, ISubDependencyResolver parentResolver,
								ComponentModel model, DependencyModel dependency)
		{
			return model.Name;
		}
		#endregion
	}
}
