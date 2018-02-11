#region

using System.Collections.Generic;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a service for retrieving registered menu definitions.
    /// </summary>
    public interface IMenuDefinitionProvider
    {
        /// <summary>
        ///     Returns an enumeration of available <see cref="MenuBarDefinition" />s.
        /// </summary>
        IEnumerable<MenuBarDefinition> MenuBars { get; }

        /// <summary>
        ///     Returns an enumeration of available <see cref="MenuDefinition" />s.
        /// </summary>
        IEnumerable<MenuDefinition> Menus { get; }

        /// <summary>
        ///     Returns an enumeration of available <see cref="SubMenuItemDefinition" />s.
        /// </summary>
        IEnumerable<SubMenuItemDefinition> SubMenuItems { get; }

        /// <summary>
        ///     Returns an enumeration of available <see cref="MenuItemGroupDefinition" />s.
        /// </summary>
        IEnumerable<MenuItemGroupDefinition> MenuItemGroups { get; }

        /// <summary>
        ///     Returns all sub menu items within the specified <see cref="MenuItemGroupDefinition" />.
        /// </summary>
        /// <param name="menuItemGroup">The <see cref="MenuItemGroupDefinition" /> to lookup.</param>
        /// <returns>
        ///     An <see cref="IEnumerable{T}" /> of <see cref="SubMenuItemDefinition" />s within the specified menu item
        ///     group.
        /// </returns>
        IEnumerable<MenuItemDefinition> GetSubMenuItemsByGroup(MenuItemGroupDefinition menuItemGroup);

        /// <summary>
        ///     Returns all groups within the specified parent <see cref="MenuItemDefinition" />.
        /// </summary>
        /// <param name="parent">The parent <see cref="MenuItemDefinition" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> of <see cref="MenuItemGroupDefinition" />s.</returns>
        IEnumerable<MenuItemGroupDefinition> GetGroupsByParentMenuItem(MenuItemDefinition parent);

        /// <summary>
        ///     Returns all menus within the specified parent <see cref="MenuBarDefinition" />.
        /// </summary>
        /// <param name="menuBar">The parent <see cref="MenuBarDefinition" />.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> of <see cref="MenuDefinition" />s.</returns>
        IEnumerable<MenuDefinition> GetMenusByMenuBar(MenuBarDefinition menuBar);
    }
}
