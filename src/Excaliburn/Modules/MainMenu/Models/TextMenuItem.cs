#region

using System.Collections;
using System.Collections.Generic;
using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MainMenu.Models
{
    /// <summary>
    ///     Represents a text menu item.
    /// </summary>
    public class TextMenuItem : MenuItem
    {
        public override string Text { get; }

        /// <summary>
        ///     Creates a new <see cref="TextMenuItem" />.
        /// </summary>
        /// <param name="definition">The definition of this item.</param>
        public TextMenuItem(TextMenuItemDefinition definition)
            : base(definition)
        {
            Text = definition.Text;
        }
    }
}
