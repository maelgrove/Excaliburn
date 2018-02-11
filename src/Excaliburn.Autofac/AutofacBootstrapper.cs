#region

using Autofac;
using Excaliburn.Composition;

#endregion

namespace Excaliburn.Autofac
{
    /// <summary>
    ///     Represents the bootstrapper and main composition root of the application, supporting Autofac.
    /// </summary>
    public class AutofacBootstrapper : Bootstrapper
    {
        /// <inheritdoc />
        protected sealed override IServiceContainer ConfigureServices(IServiceCollection components)
        {
            OnConfigureServices(components);

            var containerBuilder = new ContainerBuilder();
            OnConfigureContainer(containerBuilder);
            containerBuilder.Populate(components);

            var container = containerBuilder.Build();
            return new AutofacCompositionContainer(container);
        }

        /// <summary>
        ///     Invoked when configuring the Autofac container using the specified <see cref="ContainerBuilder" />.
        /// </summary>
        /// <param name="containerBuilder">The <see cref="ContainerBuilder" />.</param>
        protected virtual void OnConfigureContainer(ContainerBuilder containerBuilder)
        {
        }
    }
}
