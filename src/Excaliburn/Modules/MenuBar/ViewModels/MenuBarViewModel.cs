#region

using Excaliburn.Modules.MenuBar.Models;

#endregion

namespace Excaliburn.Modules.MenuBar.ViewModels
{
    /// <summary>
    ///     Represents the standard view model of the <see cref="IMenuBar" />.
    /// </summary>
    public class MenuBarViewModel : IMenuBar
    {
        /// <inheritdoc />
        public MenuBarItemCollection Items { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuBarViewModel" />.
        /// </summary>
        public MenuBarViewModel()
        {
            Items = new MenuBarItemCollection(null);
        }
    }
}
