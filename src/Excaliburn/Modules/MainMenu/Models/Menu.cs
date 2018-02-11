using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excaliburn.ComponentModel.Menus;

namespace Excaliburn.Modules.MainMenu.Models
{
    /// <summary>
    ///     Represents a top level menu item.
    /// </summary>
    public class Menu : MenuItem
    {
        public override string Text { get; }

        /// <summary>
        ///     Creates a new <see cref="Menu" />.
        /// </summary>
        /// <param name="definition">The definition of this item.</param>
        public Menu(MenuDefinition definition)
            : base(definition)
        {
            Text = definition.Header;
        }
    }
}
