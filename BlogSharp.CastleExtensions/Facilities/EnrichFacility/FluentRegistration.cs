namespace BlogSharp.CastleExtensions.Facilities.EnrichFacility
{
	using Castle.MicroKernel.Registration;

	public static class FluentRegistration
	{
		public static ComponentRegistration<T> EnrichWith<T>(this ComponentRegistration<T> registration,
																ExtendComponentDelegate action)
		{
			registration.ExtendedProperties(Property.ForKey(EnrichWithFacility.ExtendWithPropertyKey).Eq(action));
			return registration;
		}
		public static ComponentRegistration EnrichWith(this ComponentRegistration registration,
																ExtendComponentDelegate action)
		{
			registration.ExtendedProperties(Property.ForKey(EnrichWithFacility.ExtendWithPropertyKey).Eq(action));
			return registration;
		}
	}
}
