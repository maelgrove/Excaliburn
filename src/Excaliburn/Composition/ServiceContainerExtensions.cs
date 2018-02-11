using System;
using System.Collections.Generic;

namespace Excaliburn.Composition
{
    /// <summary>
    ///     Provides extensions for <see cref="IServiceContainer"/>.
    /// </summary>
    public static class ServiceContainerExtensions
    {
        /// <summary>
        ///     Gets the service object of the specified type using a key.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="container">The <see cref="IServiceContainer"/>,</param>
        /// <param name="key">The key of the service.</param>
        /// <returns>A service object of type <typeparamref name="TService" />.-or-
        ///     <see langword="null" /> if there is no service object of type <typeparamref name="TService" />.</returns>
        public static TService GetService<TService>(this IServiceContainer container, string key)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return (TService)container.GetService(typeof(TService), key);
        }

        /// <summary>
        ///     Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="container">The <see cref="IServiceContainer"/>.</param>
        /// <returns>A service object of type <typeparamref name="TService" />.-or-
        ///     <see langword="null" /> if there is no service object of type <typeparamref name="TService" />.</returns>
        public static TService GetService<TService>(this IServiceContainer container) where TService : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return (TService)container.GetService(typeof(TService));
        }

        /// <summary>
        ///     Gets an enumeration of service objects of the specified type.
        /// </summary>
        /// <typeparam name="TService">The type contract of the services.</typeparam>
        /// <param name="container">The <see cref="IServiceContainer"/>.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> of type <typeparamref name="TService"/> with the available services.</returns>
        public static IEnumerable<TService> GetServices<TService>(this IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return (IEnumerable<TService>) container.GetServices(typeof(TService));
        }
    }
}
