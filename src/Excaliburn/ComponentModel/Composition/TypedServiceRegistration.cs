#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Composition
{
    /// <summary>
    ///     Represents a <see cref="ServiceRegistration" /> which resolves implementation instances
    ///     using a specified type contract.
    /// </summary>
    public class TypedServiceRegistration : ServiceRegistration
    {
        /// <summary>
        ///     Returns the implementation type of the component.
        /// </summary>
        public Type ImplementationType { get; }

        /// <summary>
        ///     Creates a new <see cref="ServiceRegistration" />.
        /// </summary>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <param name="key">Optional key associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the registered component (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        public TypedServiceRegistration(Type serviceType, Type implementationType, string key = null,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            : base(serviceType, key, lifetime)
        {
            ImplementationType = implementationType ?? throw new ArgumentNullException(nameof(implementationType));
        }
    }
}
