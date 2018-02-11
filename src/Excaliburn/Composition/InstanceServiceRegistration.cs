#region

using System;

#endregion

namespace Excaliburn.Composition
{
    /// <summary>
    ///     Represents a <see cref="ServiceRegistration" /> which provides an already existing implementation instance.
    /// </summary>
    public class InstanceServiceRegistration : ServiceRegistration
    {
        /// <summary>
        ///     Returns the implementation instance.
        /// </summary>
        public object ImplementationInstance { get; }

        /// <summary>
        ///     Creates a new <see cref="ServiceRegistration" />.
        /// </summary>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">Optional key associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the registered component (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        public InstanceServiceRegistration(Type serviceType, object implementationInstance, string key = null,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            : base(serviceType, key, lifetime)
        {
            ImplementationInstance =
                implementationInstance ?? throw new ArgumentNullException(nameof(implementationInstance));
        }
    }
}
