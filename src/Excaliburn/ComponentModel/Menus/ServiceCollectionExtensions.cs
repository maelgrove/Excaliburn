#region

using System;
using Excaliburn.Composition;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Provides extensions for <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the services required to enable menus within the application framework.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddMenus(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            return services.AddShared<IMenuDefinitionProvider, MenuDefinitionProvider>();
        }

        /// <summary>
        ///     Adds the specified <see cref="MenuBarDefinition" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="menuBar">The <see cref="MenuBarDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddMenuBar(this IServiceCollection services, MenuBarDefinition menuBar)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (menuBar == null)
                throw new ArgumentNullException(nameof(menuBar));
            return services.AddShared(menuBar);
        }

        /// <summary>
        ///     Adds the specified <see cref="SubMenuItemDefinition" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="subMenuItem">The <see cref="SubMenuItemDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddSubMenuItem(this IServiceCollection services,
            SubMenuItemDefinition subMenuItem)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (subMenuItem == null)
                throw new ArgumentNullException(nameof(subMenuItem));
            return services.AddShared(subMenuItem);
        }

        /// <summary>
        ///     Adds the specified <see cref="MenuDefinition" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="menu">The <see cref="MenuDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddMenu(this IServiceCollection services, MenuDefinition menu)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (menu == null)
                throw new ArgumentNullException(nameof(menu));
            return services.AddShared(menu);
        }

        /// <summary>
        ///     Adds the specified <see cref="MenuItemGroupDefinition" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="menuItemGroup">The <see cref="MenuItemGroupDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddMenuItemGroup(this IServiceCollection services,
            MenuItemGroupDefinition menuItemGroup)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (menuItemGroup == null)
                throw new ArgumentNullException(nameof(menuItemGroup));
            return services.AddShared(menuItemGroup);
        }

        /// <summary>
        ///     Adds an exclusion for the specified <see cref="MenuDefinition" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="menu">The <see cref="MenuDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection ExcludeMenu(this IServiceCollection services,
            MenuDefinition menu)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (menu == null)
                throw new ArgumentNullException(nameof(menu));
            return services.AddShared(new ExcludeMenuDefinition(menu));
        }

        /// <summary>
        ///     Adds an exclusion for the specified <see cref="SubMenuItemDefinition" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="subMenuItem">The <see cref="SubMenuItemDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection ExcludeSubMenuItem(this IServiceCollection services,
            SubMenuItemDefinition subMenuItem)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (subMenuItem == null)
                throw new ArgumentNullException(nameof(subMenuItem));
            return services.AddShared(new ExcludeSubMenuItemDefinition(subMenuItem));
        }

        /// <summary>
        ///     Adds an exclusion for the specified <see cref="MenuItemGroupDefinition" /> to the <see cref="IServiceCollection" />
        ///     .
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="menuItemGroup">The <see cref="MenuItemGroupDefinition" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection ExcludeMenuItemGroup(this IServiceCollection services,
            MenuItemGroupDefinition menuItemGroup)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (menuItemGroup == null)
                throw new ArgumentNullException(nameof(menuItemGroup));
            return services.AddShared(new ExcludeMenuItemGroupDefinition(menuItemGroup));
        }
    }
}
