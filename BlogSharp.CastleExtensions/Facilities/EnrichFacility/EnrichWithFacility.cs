namespace BlogSharp.CastleExtensions.Facilities.EnrichFacility
{
	using Castle.MicroKernel;
	using Castle.MicroKernel.Facilities;

	public delegate void ExtendComponentDelegate(IKernel kernel, object item);

	public class EnrichWithFacility:AbstractFacility
	{
		public const string ExtendWithPropertyKey = "extendwith";
		protected override void Init()
		{
			Kernel.ComponentCreated += Kernel_ComponentCreated;
		}

		void Kernel_ComponentCreated(Castle.Core.ComponentModel model, object instance)
		{
			if(model.ExtendedProperties.Contains(ExtendWithPropertyKey))
			{
				var action = model.ExtendedProperties[ExtendWithPropertyKey] as ExtendComponentDelegate;
				action(this.Kernel, instance);
			}
		}
	}
}