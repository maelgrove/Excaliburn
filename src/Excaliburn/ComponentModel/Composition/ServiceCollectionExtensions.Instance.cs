#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Composition
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            TService implementationInstance, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance, null, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            TService implementationInstance, string key, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TService>(implementationInstance, key, lifetime);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance, null, lifetime);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance, string key, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(typeof(TService), implementationInstance, key, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            object implementationInstance, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance, null, lifetime);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <param name="lifetime">
        ///     Optional <see cref="ServiceLifetime" /> of the service (defaults to
        ///     <see cref="ServiceLifetime.Transient" />).
        /// </param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            object implementationInstance, string key, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            services.Add(new InstanceServiceRegistration(serviceType, implementationInstance, key, lifetime));
            return services;
        }

        #region Transient

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services,
            TService implementationInstance)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services,
            TService implementationInstance, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance, key);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance, string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance, key);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType,
            object implementationInstance)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType,
            object implementationInstance, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance, key);
        }

        #endregion

        #region Shared

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService>(this IServiceCollection services,
            TService implementationInstance)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService>(this IServiceCollection services,
            TService implementationInstance, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance, key, ServiceLifetime.Shared);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance, ServiceLifetime.Shared);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance, string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance, key, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services, Type serviceType,
            object implementationInstance)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance, ServiceLifetime.Shared);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddShared(this IServiceCollection services, Type serviceType,
            object implementationInstance, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance, key, ServiceLifetime.Shared);
        }

        #endregion

        #region Scoped

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services,
            TService implementationInstance)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <typeparam name="TService">The type contract of the service.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services,
            TService implementationInstance, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(implementationInstance, key, ServiceLifetime.Scoped);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance, ServiceLifetime.Scoped);
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
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services,
            TImplementation implementationInstance, string key)
            where TImplementation : TService
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add<TService, TImplementation>(implementationInstance, key, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType,
            object implementationInstance)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance, ServiceLifetime.Scoped);
        }

        /// <summary>
        ///     Adds the specified registration to the collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="serviceType">The type contract of the service.</param>
        /// <param name="implementationInstance">The instance to register.</param>
        /// <param name="key">The key of associated with the registration.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType,
            object implementationInstance, string key)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));
            return services.Add(serviceType, implementationInstance, key, ServiceLifetime.Scoped);
        }

        #endregion
    }
}
