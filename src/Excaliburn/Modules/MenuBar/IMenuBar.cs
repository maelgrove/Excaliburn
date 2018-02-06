#region

using Excaliburn.Modules.MenuBar.Models;

#endregion

namespace Excaliburn.Modules.MenuBar
{
    /// <summary>
    ///     Represents the menu bar within the shell.
    /// </summary>
    public interface IMenuBar
    {
        /// <summary>
        ///     Returns a collection of items within the menu bar.
        /// </summary>
        MenuBarItemCollection Items { get; }
    }
}
