using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model.Validation;
using BlogSharp.Model.Validation.Interfaces;
using Castle.MicroKernel;
using Castle.Windsor;
using Db4objects.Db4o.Events;
using Db4objects.Db4o.Ext;
using FluentValidation;

namespace BlogSharp.Db4o.Blog
{
    public class ValidationWiringDb4oInitializationHandler : IDb4oInitializationHandler
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
            factory.Creating += ValidationHandler;
            factory.Updating += ValidationHandler;
        }

        protected void ValidationHandler(object sender, CancellableObjectEventArgs args)
        {
            try
            {
                ValidateObject(args.Object);
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
            var validatorType = typeof(IValidatorBase<>).MakeGenericType(type);
            if (container.HasComponent(validatorType))
            {
                var validator = container.Resolve(validatorType) as IValidatorBase;
                validator.ValidateAndThrowException(obj);

            }
        }

        #endregion
    }
}
