#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a definition within the composition model of the framework
    ///     which can be used to exclude already registered <see cref="MenuDefinition" />s.
    /// </summary>
    public class ExcludeMenuDefinition
    {
        /// <summary>
        ///     Returns the <see cref="SubMenuItemDefinition" /> to exclude.
        /// </summary>
        public MenuDefinition ExcludedDefinition { get; }

        /// <summary>
        ///     Creates a new <see cref="ExcludeMenuDefinition" />.
        /// </summary>
        /// <param name="excludedDefinition">The <see cref="MenuDefinition" /> to exclude.</param>
        public ExcludeMenuDefinition(MenuDefinition excludedDefinition)
        {
            ExcludedDefinition = excludedDefinition ?? throw new ArgumentNullException(nameof(excludedDefinition));
        }
    }
}
