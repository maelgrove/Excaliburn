
using System;
using Excaliburn.Composition;

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Provides extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the services required to enable commanding within the application framework.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCommanding(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddShared<ICommandStateCache, CommandStateCache>();

            // TODO add command related services
            return services;
        }

        /// <summary>
        ///     Adds the specified command definition to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TCommandDefinition">The type of the command definition, inheriting from <see cref="CommandDefinition"/>.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCommand<TCommandDefinition>(this IServiceCollection services) 
            where TCommandDefinition : CommandDefinition
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.AddShared<CommandDefinition, TCommandDefinition>();
        }

        /// <summary>
        ///     Adds the specified command definition to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TCommandHandler">The type of the command handler, implementing <see cref="ICommandHandler"/>.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCommandHandler<TCommandHandler>(this IServiceCollection services)
            where TCommandHandler : ICommandHandler
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.AddTransient<TCommandHandler>();
        }

        /// <summary>
        ///     Adds the specified command binding to the <see cref="IServiceCollection"/>,
        ///     consisting of a command definition and associated command handler.
        /// </summary>
        /// <typeparam name="TCommandDefinition">The type of the command definition, inheriting from <see cref="CommandDefinition"/>.</typeparam>
        /// <typeparam name="TCommandHandler">The type of the command handler, implementing <see cref="ICommandHandler"/>.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCommand<TCommandDefinition, TCommandHandler>(
            this IServiceCollection services)
            where TCommandDefinition : CommandDefinition<TCommandHandler>
            where TCommandHandler : ICommandHandler
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services
                .AddCommand<TCommandDefinition>()
                .AddCommandHandler<TCommandHandler>();
        }
    }
}
