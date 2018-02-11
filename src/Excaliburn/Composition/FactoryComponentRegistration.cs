#region

using System;

#endregion

namespace Excaliburn.Composition
{
    /// <summary>
    ///     Represents a <see cref="ServiceRegistration" /> which resolves the implementation
    ///     from a provided factory delegate.
    /// </summary>
    public class FactoryComponentRegistration : ServiceRegistration
    {
        /// <summary>
        ///     Returns the implementation factory.
        /// </summary>
        public Func<IServiceContainer, object> ImplementationFactory { get; }

        /// <summary>
        ///     Creates a new <see cref="FactoryComponentRegistration" />.
        /// </summary>
        /// <param name="serviceType">The contract type of registered service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">Optional key associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the registered service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        public FactoryComponentRegistration(Type serviceType,
            Func<IServiceContainer, object> implementationFactory, string key = null,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            : base(serviceType, key, lifetime)
        {
            ImplementationFactory =
                implementationFactory ?? throw new ArgumentNullException(nameof(implementationFactory));
        }
    }
}
