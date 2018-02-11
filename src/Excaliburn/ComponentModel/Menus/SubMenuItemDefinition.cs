#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a definition of a sub menu item within the composition model of the framework.
    ///     Sub menu items are menu items located within a group.
    /// </summary>
    public abstract class SubMenuItemDefinition : MenuItemDefinition
    {
        /// <summary>
        ///     Returns the parent <see cref="MenuItemGroupDefinition" /> of the item.
        /// </summary>
        public MenuItemGroupDefinition Group { get; }

        /// <summary>
        ///     Creates a new <see cref="SubMenuItemDefinition" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        protected SubMenuItemDefinition(MenuItemGroupDefinition group, int sortOrder = 0)
            : base(sortOrder)
        {
            Group = group ?? throw new ArgumentNullException();
        }
    }
}
