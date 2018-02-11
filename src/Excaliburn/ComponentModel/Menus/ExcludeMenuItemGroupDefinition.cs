#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a definition within the composition model of the framework
    ///     which can be used to exclude already registered <see cref="MenuItemGroupDefinition" />s.
    /// </summary>
    public class ExcludeMenuItemGroupDefinition
    {
        /// <summary>
        ///     Returns the <see cref="MenuItemGroupDefinition" /> to exclude.
        /// </summary>
        public MenuItemGroupDefinition ExcludedDefinition { get; }

        /// <summary>
        ///     Creates a new <see cref="ExcludeSubMenuItemDefinition" />.
        /// </summary>
        /// <param name="excludedDefinition">The <see cref="MenuItemGroupDefinition" /> to exclude.</param>
        public ExcludeMenuItemGroupDefinition(MenuItemGroupDefinition excludedDefinition)
        {
            ExcludedDefinition = excludedDefinition ?? throw new ArgumentNullException(nameof(excludedDefinition));
        }
    }
}
