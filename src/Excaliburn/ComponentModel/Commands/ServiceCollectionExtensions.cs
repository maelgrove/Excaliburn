
using Excaliburn.ComponentModel.Composition;

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
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            // TODO implement
            return services;
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
            services.AddShared<TCommandDefinition>();
            services.AddTransient<TCommandHandler>();
            return services;
        }

        /// <summary>
        ///     Adds the specified <see cref="CommandKeyGesture"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TCommandDefinition"></typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="commandKeyGesture">The <see cref="CommandKeyGesture"/> to add.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCommandKeyGesture<TCommandDefinition>(this IServiceCollection services,
            CommandKeyGesture<TCommandDefinition> commandKeyGesture) 
            where TCommandDefinition : CommandDefinition => services.AddShared<CommandKeyGesture>(commandKeyGesture);
    }
}
