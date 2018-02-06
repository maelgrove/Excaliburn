#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a base type for definitions of menu items within the composition model
    ///     of the framework. Menu items are single entries within a menu bar, grouped in
    ///     menu item groups (see <see cref="MenuItemGroupDefinition" />).
    /// </summary>
    public abstract class MenuItemDefinition
    {
        /// <summary>
        ///     Returns the parent <see cref="MenuItemGroupDefinition" /> of the item.
        /// </summary>
        public MenuItemGroupDefinition Group { get; }

        /// <summary>
        ///     Returns the sort order of the item.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuItemDefinition" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        internal MenuItemDefinition(MenuItemGroupDefinition group, int sortOrder = 0)
        {
            Group = group ?? throw new ArgumentNullException(nameof(group));
            SortOrder = sortOrder;
        }
    }
}
