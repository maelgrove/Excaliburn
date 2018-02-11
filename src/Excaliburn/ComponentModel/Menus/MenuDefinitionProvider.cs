#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents the default <see cref="IMenuDefinitionProvider" /> implementation.
    /// </summary>
    internal class MenuDefinitionProvider : IMenuDefinitionProvider
    {
        /// <inheritdoc />
        public IEnumerable<MenuBarDefinition> MenuBars { get; }

        /// <inheritdoc />
        public IEnumerable<MenuDefinition> Menus { get; }

        public IEnumerable<SubMenuItemDefinition> SubMenuItems { get; }

        /// <inheritdoc />
        public IEnumerable<MenuItemGroupDefinition> MenuItemGroups { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuDefinitionProvider" />.
        /// </summary>
        /// <param name="menuBars">The available <see cref="MenuBarDefinition" />s.</param>
        /// <param name="menuDefinitions">The available <see cref="MenuDefinition" />.</param>
        /// <param name="excludedMenus">The available <see cref="ExcludeMenuDefinition" />.</param>
        /// <param name="menuItemGroups">The available <see cref="MenuItemGroupDefinition" />s.</param>
        /// <param name="excludedMenuItemGroups">The available <see cref="ExcludeMenuItemGroupDefinition" />s.</param>
        /// <param name="subMenuItems">The available <see cref="SubMenuItemDefinition" />s.</param>
        /// <param name="excludedMenuItems">The available <see cref="ExcludeSubMenuItemDefinition" />s.</param>
        public MenuDefinitionProvider(
            IEnumerable<MenuBarDefinition> menuBars,
            IEnumerable<MenuDefinition> menuDefinitions,
            IEnumerable<ExcludeMenuDefinition> excludedMenus,
            IEnumerable<MenuItemGroupDefinition> menuItemGroups,
            IEnumerable<ExcludeMenuItemGroupDefinition> excludedMenuItemGroups,
            IEnumerable<SubMenuItemDefinition> subMenuItems,
            IEnumerable<ExcludeSubMenuItemDefinition> excludedMenuItems)
        {
            if (menuItemGroups == null)
                throw new ArgumentNullException(nameof(menuItemGroups));
            if (excludedMenuItemGroups == null)
                throw new ArgumentNullException(nameof(excludedMenuItemGroups));
            if (subMenuItems == null)
                throw new ArgumentNullException(nameof(subMenuItems));
            if (excludedMenuItems == null)
                throw new ArgumentNullException(nameof(excludedMenuItems));

            MenuBars = menuBars ?? throw new ArgumentNullException(nameof(menuBars));
            Menus = menuDefinitions.Where(menu => !excludedMenus.Select(exclude => exclude.ExcludedDefinition)
                .Contains(menu));
            MenuItemGroups = menuItemGroups.Where(group =>
                !excludedMenuItemGroups.Select(exclude => exclude.ExcludedDefinition)
                    .Contains(group));
            SubMenuItems = subMenuItems.Where(item =>
                !excludedMenuItems.Select(exclude => exclude.ExcludedDefinition)
                    .Contains(item));
        }

        /// <inheritdoc />
        public IEnumerable<MenuItemDefinition> GetSubMenuItemsByGroup(MenuItemGroupDefinition menuItemGroup) =>
            SubMenuItems.Where(subMenuItem => subMenuItem.Group == menuItemGroup);

        /// <inheritdoc />
        public IEnumerable<MenuItemGroupDefinition> GetGroupsByParentMenuItem(MenuItemDefinition parent) =>
            MenuItemGroups.Where(group => group.Parent == parent);

        /// <inheritdoc />
        public IEnumerable<MenuDefinition> GetMenusByMenuBar(MenuBarDefinition menuBar) =>
            Menus.Where(menu => menu.MenuBar == menuBar);
    }
}
