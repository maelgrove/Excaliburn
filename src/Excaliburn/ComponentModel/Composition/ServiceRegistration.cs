#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Composition
{
    /// <summary>
    ///     Represents a base type for service registrations.
    /// </summary>
    public abstract class ServiceRegistration
    {
        /// <summary>
        ///     Returns the type contract of the service.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        ///     Returns a key associated with the registration.
        /// </summary>
        public string Key { get; }

        /// <summary>
        ///     Returns the <see cref="ServiceLifetime" /> of the registered service.
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        ///     Creates a new <see cref="ServiceRegistration" />.
        /// </summary>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="key">Optional key associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the registered component (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        internal ServiceRegistration(Type serviceType, string key = null,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            ServiceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
            Key = key;
            Lifetime = lifetime;
        }
    }
}
