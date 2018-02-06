#region

using System;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents the definition of a standard text menu item. Text menu items are simple
    ///     menu items which can be used for displaying categories.
    /// </summary>
    public class TextMenuItemDefinition : MenuItemDefinition
    {
        /// <summary>
        ///     Returns the display text of the item.
        /// </summary>
        public string Text { get; }

        /// <summary>
        ///     Creates a new <see cref="TextMenuItemDefinition" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="text">The display text of the item.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        public TextMenuItemDefinition(MenuItemGroupDefinition group, string text, int sortOrder = 0)
            : base(group, sortOrder)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
