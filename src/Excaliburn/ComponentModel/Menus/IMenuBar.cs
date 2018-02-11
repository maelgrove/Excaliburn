using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excaliburn.Modules.MainMenu.Models;

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a menu bar.
    /// </summary>
    public interface IMenuBar
    {
        /// <summary>
        ///     Returns the definition of the menu bar.
        /// </summary>
        MenuBarDefinition Definition { get; }

        /// <summary>
        ///     Returns the items within the menu bar.
        /// </summary>
        MenuBarItemCollection Items { get; }
    }
}
