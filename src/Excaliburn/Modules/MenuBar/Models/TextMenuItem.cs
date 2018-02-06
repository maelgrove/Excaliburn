#region

using System.Collections;
using System.Collections.Generic;
using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MenuBar.Models
{
    /// <summary>
    ///     Represents a text menu item.
    /// </summary>
    public class TextMenuItem : MenuItem<TextMenuItemDefinition>, IEnumerable<MenuBarItem>
    {
        /// <summary>
        ///     Returns an observable collection of child items of this menu item.
        /// </summary>
        public ICollection<MenuBarItem> Children { get; }

        /// <summary>
        ///     Returns the display text of the item.
        /// </summary>
        public string Text { get; }

        /// <summary>
        ///     Creates a new <see cref="TextMenuItem" />.
        /// </summary>
        /// <param name="definition">The definition of this item.</param>
        public TextMenuItem(TextMenuItemDefinition definition)
            : base(definition)
        {
            Children = new MenuBarItemCollection(this);
            Text = definition.Text;
        }

        /// <inheritdoc />
        public IEnumerator<MenuBarItem> GetEnumerator() => Children.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
