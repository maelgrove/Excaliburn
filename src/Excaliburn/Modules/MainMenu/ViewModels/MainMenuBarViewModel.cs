#region

using System;
using Excaliburn.ComponentModel.Menus;
using Excaliburn.Modules.MainMenu.Models;
using Excaliburn.Modules.MainMenu.Services;

#endregion

namespace Excaliburn.Modules.MainMenu.ViewModels
{
    /// <summary>
    ///     Represents the standard view model of the <see cref="IMainMenuBar" />.
    /// </summary>
    internal class MainMenuBarViewModel : IMainMenuBar
    {
        /// <inheritdoc />
        public MenuBarDefinition Definition => MenuDefinitions.MainMenuBar;

        /// <inheritdoc />
        public MenuBarItemCollection Items { get; } = new MenuBarItemCollection();

        /// <summary>
        ///     Creates a new <see cref="MainMenuBarViewModel" />.
        /// </summary>
        /// <param name="menuBarBuilder">The <see cref="MenuBarBuilder"/>.</param>
        public MainMenuBarViewModel(MenuBarBuilder menuBarBuilder)
        {
            if(menuBarBuilder == null)
                throw new ArgumentNullException(nameof(menuBarBuilder));
            menuBarBuilder.PopulateMenuBar(Definition, Items);
        }
    }
}
