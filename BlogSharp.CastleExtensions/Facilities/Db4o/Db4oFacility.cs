using Castle.MicroKernel.Facilities;

namespace BlogSharp.CastleExtensions.Facilities.Db4o
{
	public class Db4oFacility : AbstractFacility
	{
		protected override void Init()
		{
			RegisterComponents();
		}

		private void RegisterComponents()
		{
			RegisterSessionManager();
		}

		private void RegisterSessionManager()
		{
			Kernel.AddComponent("db4o.facility", typeof(ISessionManager), typeof(BlogSharpSessionManager));
		}
	}
}
