namespace BlogSharp.Db4o.Blog
{
	using Castle.MicroKernel;
	using Db4objects.Db4o.Events;
	using Db4objects.Db4o.Ext;
	using Model.Validation;
	using Model.Validation.Interfaces;

	public class ValidationWiringDb4oInitializationHandler : IDb4oInitializationHandler
	{
		private readonly IKernel container;

		public ValidationWiringDb4oInitializationHandler(IKernel container)
		{
			this.container = container;
		}

		#region IDb4oInitializationHandler Members

		public void HandleObjectContainerCreated(IExtObjectContainer extObjectContainer)
		{
			var factory = EventRegistryFactory.ForObjectContainer(extObjectContainer);
			factory.Creating += this.ValidationHandler;
			factory.Updating += this.ValidationHandler;
		}

		#endregion

		protected void ValidationHandler(object sender, CancellableObjectEventArgs args)
		{
			try
			{
				this.ValidateObject(args.Object);
			}
			catch (ValidationException ex)
			{
				args.Cancel();
				throw ex;
			}
		}

		protected virtual void ValidateObject<T>(T obj)
		{
			var type = obj.GetType();
			var validatorType = typeof (IValidatorBase<>).MakeGenericType(type);
			if (this.container.HasComponent(validatorType))
			{
				var validator = this.container.Resolve(validatorType) as IValidatorBase;
				validator.ValidateAndThrowException(obj);
			}
		}
	}
}