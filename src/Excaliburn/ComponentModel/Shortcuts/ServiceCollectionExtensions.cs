using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excaliburn.ComponentModel.Commands;
using Excaliburn.Composition;

namespace Excaliburn.ComponentModel.Shortcuts
{
    /// <summary>
    ///     Provides extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds services to the <see cref="IServiceCollection"/> to enable shortcuts.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddShortcuts(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.AddShared<IShortcutDefinitionProvider, ShortcutDefinitionProvider>();
        }

        /// <summary>
        ///     Adds the specified <see cref="ShortcutDefinition"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TCommandDefinition">The type contract of the command definition, inheriting from <see cref="CommandDefinition"/>.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="shortcut">The <see cref="ShortcutDefinition"/> to add.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddShortcut<TCommandDefinition>(this IServiceCollection services,
            ShortcutDefinition<TCommandDefinition> shortcut)
            where TCommandDefinition : CommandDefinition
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.AddShared<ShortcutDefinition>(shortcut);
        }
    }
}
