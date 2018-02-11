#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a definition within the composition model of the framework
    ///     which can be used to exclude already registered <see cref="SubMenuItemDefinition" />s.
    /// </summary>
    public class ExcludeSubMenuItemDefinition
    {
        /// <summary>
        ///     Returns the <see cref="SubMenuItemDefinition" /> to exclude.
        /// </summary>
        public SubMenuItemDefinition ExcludedDefinition { get; }

        /// <summary>
        ///     Creates a new <see cref="ExcludeSubMenuItemDefinition" />.
        /// </summary>
        /// <param name="excludedDefinition">The <see cref="SubMenuItemDefinition" /> to exclude.</param>
        public ExcludeSubMenuItemDefinition(SubMenuItemDefinition excludedDefinition)
        {
            ExcludedDefinition = excludedDefinition ?? throw new ArgumentNullException(nameof(excludedDefinition));
        }
    }
}
