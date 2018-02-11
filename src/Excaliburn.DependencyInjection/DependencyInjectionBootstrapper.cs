#region

using System;
using Excaliburn.Composition;

#endregion

namespace Excaliburn.DependencyInjection
{
    /// <summary>
    ///     Represents the bootstrapper and main composition root of the application, supporting
    ///     Microsoft Extensions DependencyInjection.
    /// </summary>
    public class DependencyInjectionBootstrapper : Bootstrapper
    {
        protected override IServiceContainer ConfigureServices(IServiceCollection components)
        {
            throw new NotImplementedException();
        }
    }
}
