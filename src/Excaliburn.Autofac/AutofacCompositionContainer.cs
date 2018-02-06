#region

using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Excaliburn.ComponentModel.Composition;

#endregion

namespace Excaliburn.Autofac
{
    internal class AutofacCompositionContainer : IServiceContainer, IDisposable
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacCompositionContainer(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public void Dispose() => _lifetimeScope.Dispose();

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            return GetService(serviceType, null);
        }

        public object GetService(Type serviceType, string key)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            return !string.IsNullOrEmpty(key)
                ? _lifetimeScope.ResolveOptionalService(new KeyedService(key, serviceType))
                : _lifetimeScope.ResolveOptional(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            return _lifetimeScope.Resolve(typeof(IEnumerable<>).MakeGenericType(serviceType)) as IEnumerable<object>;
        }

        public void BuildUp(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
            _lifetimeScope.InjectProperties(instance);
        }
    }
}
