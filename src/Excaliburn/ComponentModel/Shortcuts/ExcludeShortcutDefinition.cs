using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excaliburn.ComponentModel.Shortcuts
{
    /// <summary>
    ///     Represents a definition to exclude a previously registered <see cref="ShortcutDefinition"/>.
    /// </summary>
    public class ExcludeShortcutDefinition
    {
        /// <summary>
        ///     Returns the <see cref="ShortcutDefinition"/> to exclude.
        /// </summary>
        public ShortcutDefinition ExcludedDefinition { get; }

        /// <summary>
        ///     Creates a new <see cref="ExcludeShortcutDefinition"/>.
        /// </summary>
        /// <param name="excludedDefinition">The <see cref="ShortcutDefinition"/> to exclude.</param>
        public ExcludeShortcutDefinition(ShortcutDefinition excludedDefinition)
        {
            ExcludedDefinition = excludedDefinition ?? throw new ArgumentNullException(nameof(excludedDefinition));
        }
    }
}
