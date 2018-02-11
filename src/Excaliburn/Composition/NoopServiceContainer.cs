#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Excaliburn.Composition
{
    internal class NoopServiceContainer : IServiceContainer
    {
        public static readonly NoopServiceContainer Default = new NoopServiceContainer();

        private NoopServiceContainer()
        {
        }

        public object GetService(Type serviceType) => null;

        public object GetService(Type serviceType, string key) => null;

        public IEnumerable<object> GetServices(Type serviceType) => Enumerable.Empty<object>();

        public void BuildUp(object instance)
        {
        }
    }
}
