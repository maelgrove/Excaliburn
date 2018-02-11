#region

using System;
using System.Collections;
using System.Collections.Generic;
using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MainMenu.Models
{
    /// <summary>
    ///     Represents a menu item.
    /// </summary>
    public abstract class MenuItem : MenuBarItem, IEnumerable<MenuBarItem>
    {
        /// <summary>
        ///     Returns the definition of this item.
        /// </summary>
        public MenuItemDefinition Definition { get; }

        /// <summary>
        ///     Returns an observable collection of child items of this menu item.
        /// </summary>
        public MenuBarItemCollection Children { get; }

        /// <summary>
        ///     Returns the display text of the item.
        /// </summary>
        public abstract string Text { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuItem" />.
        /// </summary>
        /// <param name="definition">The definition of this item.</param>
        protected MenuItem(MenuItemDefinition definition)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
        }

        /// <inheritdoc />
        public IEnumerator<MenuBarItem> GetEnumerator() => Children.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
