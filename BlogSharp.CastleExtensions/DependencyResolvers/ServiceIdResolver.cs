namespace BlogSharp.CastleExtensions.DependencyResolvers
{
	using Castle.Core;
	using Castle.MicroKernel;

	public class ServiceIdResolver : ISubDependencyResolver
	{
		#region ISubDependencyResolver Members

		public bool CanResolve(CreationContext context, ISubDependencyResolver parentResolver,
		                       ComponentModel model, DependencyModel dependency)
		{
			return dependency.DependencyKey.ToLowerInvariant().Equals("serviceid") &&
			       dependency.TargetType == typeof (string);
		}

		public object Resolve(CreationContext context, ISubDependencyResolver parentResolver,
		                      ComponentModel model, DependencyModel dependency)
		{
			return model.Name;
		}

		#endregion
	}
}