using System;
using Excaliburn.ComponentModel.Menus;
using Excaliburn.Composition;
using Excaliburn.Modules.MainMenu.Services;
using Excaliburn.Modules.MainMenu.ViewModels;

namespace Excaliburn.Modules.MainMenu
{
    /// <summary>
    ///     Provides extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds services required to enable the menu bar module to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMainMenu(this IServiceCollection services)
        {
            if(services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddShared<IMainMenuBar, MainMenuBarViewModel>();
            services.AddMenuBar(MenuDefinitions.MainMenuBar);
            services.AddTransient<MenuBarBuilder>();
            return services;
        }
    }
}
