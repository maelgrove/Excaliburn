#region

using System;
using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MenuBar.Models
{
    /// <summary>
    ///     Represents a menu item.
    /// </summary>
    public abstract class MenuItem<TMenuItemDefinition> : MenuBarItem
        where TMenuItemDefinition : MenuItemDefinition
    {
        /// <summary>
        ///     Returns the definition of this item.
        /// </summary>
        public TMenuItemDefinition Definition { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuItem{TMenuItemDefinition}" />.
        /// </summary>
        /// <param name="definition">The definition of this item.</param>
        protected MenuItem(TMenuItemDefinition definition)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
        }
    }
}
