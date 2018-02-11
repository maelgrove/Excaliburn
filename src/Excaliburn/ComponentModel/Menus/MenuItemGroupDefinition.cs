#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents the definition of a group of menu items. Menu item groups are
    ///     used for grouping individual menu items (see <see cref="MenuItemDefinition" />) and
    ///     put them in a hierarchical structure through nesting them within text menus.
    /// </summary>
    public class MenuItemGroupDefinition
    {
        /// <summary>
        ///     Returns the parent <see cref="TextMenuItemDefinition" /> of the group.
        /// </summary>
        public MenuItemDefinition Parent { get; }

        /// <summary>
        ///     Returns the sort order of the group.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuItemGroupDefinition" />.
        /// </summary>
        /// <param name="parent">Optional parent <see cref="MenuItemDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        public MenuItemGroupDefinition(MenuItemDefinition parent, int sortOrder = 0)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            SortOrder = sortOrder;
        }
    }
}
