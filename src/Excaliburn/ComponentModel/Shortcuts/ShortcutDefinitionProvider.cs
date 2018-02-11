using System;
using System.Collections.Generic;
using System.Linq;
using Excaliburn.ComponentModel.Commands;

namespace Excaliburn.ComponentModel.Shortcuts
{
    /// <summary>
    ///     Represents the default <see cref="IShortcutDefinitionProvider"/> implementation.
    /// </summary>
    internal class ShortcutDefinitionProvider : IShortcutDefinitionProvider
    {
        /// <inheritdoc />
        public IEnumerable<ShortcutDefinition> Shortcuts { get; }

        /// <summary>
        ///     Creates a new <see cref="ShortcutDefinitionProvider"/>.
        /// </summary>
        /// <param name="shortcuts">The <see cref="ShortcutDefinition"/>s.</param>
        /// <param name="excludedShortcuts">The <see cref="ExcludeShortcutDefinition"/>s.</param>
        public ShortcutDefinitionProvider(
            IEnumerable<ShortcutDefinition> shortcuts,
            IEnumerable<ExcludeShortcutDefinition> excludedShortcuts)
        {
            if(shortcuts == null)
                throw new ArgumentNullException(nameof(shortcuts));
            if (excludedShortcuts == null)
                throw new ArgumentNullException(nameof(excludedShortcuts));
            Shortcuts = shortcuts.Where(shortcut =>
                !excludedShortcuts.Select(excluded => excluded.ExcludedDefinition)
                .Contains(shortcut));
        }

        /// <inheritdoc />
        public IEnumerable<ShortcutDefinition> GetShortcutsForCommand(CommandDefinition commandDefinition)
        {
            if(commandDefinition == null)
                throw new ArgumentNullException(nameof(commandDefinition));
            return Shortcuts.Where(shortcut => shortcut.CommandDefinitionType == commandDefinition.GetType());
        }

        /// <inheritdoc />
        public ShortcutDefinition GetPrimaryShortcutForCommand(CommandDefinition commandDefinition)
        {
            if (commandDefinition == null)
                throw new ArgumentNullException(nameof(commandDefinition));
            return GetShortcutsForCommand(commandDefinition)
                .OrderBy(shortcut => shortcut.SortOrder)
                .FirstOrDefault();
        }
    }
}
