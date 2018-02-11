using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excaliburn.ComponentModel.Commands;

namespace Excaliburn.ComponentModel.Shortcuts
{
    /// <summary>
    ///     Represents a service which provides registered <see cref="ShortcutDefinition"/>s.
    /// </summary>
    public interface IShortcutDefinitionProvider
    {
        /// <summary>
        ///     Returns the registered <see cref="ShortcutDefinition"/>s.
        /// </summary>
        IEnumerable<ShortcutDefinition> Shortcuts { get; }

        /// <summary>
        ///     Returns all registered <see cref="ShortcutDefinition"/>s for the specified <see cref="CommandDefinition"/>.
        /// </summary>
        /// <param name="commandDefinition">The <see cref="CommandDefinition"/> to look up.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CommandDefinition"/>s.</returns>
        IEnumerable<ShortcutDefinition> GetShortcutsForCommand(CommandDefinition commandDefinition);

        ShortcutDefinition GetPrimaryShortcutForCommand(CommandDefinition commandDefinition);
    }
}
