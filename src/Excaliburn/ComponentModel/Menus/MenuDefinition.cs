#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents the definition of a menu within the composition model of the framework.
    ///     Menus are the top level menu items within a menu bar and can contain an arbitary number
    ///     of sub-items contained in menu item groups.
    /// </summary>
    public class MenuDefinition : MenuItemDefinition
    {
        /// <summary>
        ///     Returns the header of the menu, which is the text displayed within the menu bar.
        /// </summary>
        public string Header { get; }

        /// <summary>
        ///     Returns the parent <see cref="MenuBarDefinition" />.
        /// </summary>
        public MenuBarDefinition MenuBar { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuDefinition" /> using a parent <see cref="MenuBarDefinition" />
        ///     and header text.
        /// </summary>
        /// <param name="menuBar">The parent <see cref="MenuBarDefinition" /> of the menu.</param>
        /// <param name="header">The header text, which is being displayed within the menu bar.</param>
        /// <param name="sortOrder">Optional sort order of the menu (defaults to 0).</param>
        public MenuDefinition(MenuBarDefinition menuBar, string header, int sortOrder = 0)
            : base(sortOrder)
        {
            MenuBar = menuBar ?? throw new ArgumentNullException(nameof(menuBar));
            Header = header ?? throw new ArgumentNullException(nameof(header));
        }
    }
}
