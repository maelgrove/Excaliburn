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
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(null as string, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services, string key,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TService>(key, lifetime);
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
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(null as string, lifetime);
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
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services, string key,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add(typeof(TService), typeof(TImplementation), key, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            Type implementationType, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, null, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            Type implementationType, string key,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            services.Add(new TypedServiceRegistration(serviceType, implementationType, key, lifetime));
            return services;
        }

        #region Transient

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(null as string);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(key);
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
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(null as string);
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
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services,
            string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(key);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType,
            Type implementationType)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, null);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType,
            Type implementationType, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, key);
        }

        #endregion

        #region Shared

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService>(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(null as string, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService>(this IServiceCollection services, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(key, ServiceLifetime.Shared);
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
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(null as string, ServiceLifetime.Shared);
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
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService, TImplementation>(this IServiceCollection services,
            string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(key, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services, Type serviceType,
            Type implementationType)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, null, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services, Type serviceType,
            Type implementationType, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, key, ServiceLifetime.Shared);
        }

        #endregion

        #region Scoped

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(null as string, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService>(key, ServiceLifetime.Scoped);
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
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(null as string, ServiceLifetime.Scoped);
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
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services,
            string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.Add<TService, TImplementation>(key, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType,
            Type implementationType)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, null, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationType">The type contract of the implementation.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType,
            Type implementationType, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationType == null)
                throw new ArgumentNullException(nameof(implementationType));
            return services.Add(serviceType, implementationType, key, ServiceLifetime.Scoped);
        }

        #endregion
    }
}
