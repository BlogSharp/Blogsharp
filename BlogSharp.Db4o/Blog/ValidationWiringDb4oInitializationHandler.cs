using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model.Validation;
using Castle.MicroKernel;
using Castle.Windsor;
using Db4objects.Db4o.Events;
using Db4objects.Db4o.Ext;
using FluentValidation;

namespace BlogSharp.Db4o.Blog
{
	public class ValidationWiringDb4oInitializationHandler:IDb4oInitializationHandler
	{
		public ValidationWiringDb4oInitializationHandler(IKernel container)
		{
			this.container = container;
		}

		private readonly IKernel container;
		#region IDb4oInitializationHandler Members

		public void HandleObjectContainerCreated(IExtObjectContainer extObjectContainer)
		{
			var factory = EventRegistryFactory.ForObjectContainer(extObjectContainer);
			factory.Creating += factory_Creating;
			factory.Updating += factory_Updating;
		}

		protected void factory_Updating(object sender, CancellableObjectEventArgs args)
		{
			ValidateObject(args.Object);
		}

		protected void factory_Creating(object sender, CancellableObjectEventArgs args)
		{
			ValidateObject(args.Object);
		}

		protected virtual void ValidateObject<T>(T obj)
		{
			var type = obj.GetType();
			var validatorType=typeof (IValidatorBase<>).MakeGenericType(type);
			if(container.HasComponent(validatorType))
			{
				var validator = container.Resolve(validatorType) as IValidatorBase;
				validator.ValidateAndThrowException(obj);				
			}
		}
		#endregion
	}
}
