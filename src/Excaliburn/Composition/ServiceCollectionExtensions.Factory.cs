#region

using System;

#endregion

namespace Excaliburn.Composition
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory, null, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory,
            string key, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TService>(implementationFactory, key, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory, null, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory,
            string key, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(typeof(TService), container => implementationFactory(container), key, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory, null, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory, string key,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            services.Add(new FactoryComponentRegistration(serviceType, implementationFactory, key, lifetime));
            return services;
        }

        #region Transient

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory,
            string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory, key);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory,
            string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory, key);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory, key);
        }

        #endregion

        #region Shared

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory,
            string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory, key, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory,
            string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory, key, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory, key, ServiceLifetime.Shared);
        }

        #endregion

        #region Scoped

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services,
            Func<IServiceContainer, TService> implementationFactory,
            string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(implementationFactory, key, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <typeparam name="TImplementation">
        ///     The type contract of the implementation, implementing
        ///     <typeparamref name="TService" />.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceContainer, TImplementation> implementationFactory,
            string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add<TService, TImplementation>(implementationFactory, key, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationFactory">The implementation factory.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType,
            Func<IServiceContainer, object> implementationFactory, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));
            return services.Add(serviceType, implementationFactory, key, ServiceLifetime.Scoped);
        }

        #endregion
    }
}
