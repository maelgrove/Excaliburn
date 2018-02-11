#region

using System;
using System.Collections.Generic;

#endregion

namespace Excaliburn.Composition
{
    /// <summary>
    ///     Represents a container where registered services can be resolved.
    /// </summary>
    public interface IServiceContainer : IServiceProvider
    {
        /// <summary>
        ///     Gets the service object of the specified type using a key.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <param name="key">The key of the service.</param>
        /// <returns>
        ///     A service object of type <paramref name="serviceType" />.-or-
        ///     <see langword="null" /> if there is no service object of type <paramref name="serviceType" />.
        /// </returns>
        object GetService(Type serviceType, string key);

        /// <summary>
        ///     Gets an enumeration of service objects of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service objects to get.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> of type <paramref name="serviceType" /> with the available services.</returns>
        IEnumerable<object> GetServices(Type serviceType);

        /// <summary>
        ///     Builds up the specified instance.
        /// </summary>
        /// <param name="instance">The instance to build up.</param>
        void BuildUp(object instance);
    }
}
