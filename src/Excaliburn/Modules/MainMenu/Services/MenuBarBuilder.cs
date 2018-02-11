using System;
using System.Linq;
using Excaliburn.ComponentModel.Commands;
using Excaliburn.ComponentModel.Menus;
using Excaliburn.Modules.MainMenu.Models;

namespace Excaliburn.Modules.MainMenu.Services
{
    /// <summary>
    ///     Represents a small utility service for populating the <see cref="IMenuBar"/>.
    /// </summary>
    internal class MenuBarBuilder
    {
        private readonly IMenuDefinitionProvider _menuDefinitionService;
        private readonly ICommandHandlerResolver _commandRouter;

        /// <summary>
        ///     Creates a new <see cref="MenuBarBuilder"/>.
        /// </summary>
        /// <param name="menuDefinitionService">The <see cref="IMenuDefinitionProvider"/>.</param>
        /// <param name="commandRouter">The <see cref="ICommandHandlerResolver"/>.</param>
        public MenuBarBuilder(IMenuDefinitionProvider menuDefinitionService, ICommandHandlerResolver commandRouter)
        {
            _menuDefinitionService = menuDefinitionService 
                ?? throw new ArgumentNullException(nameof(menuDefinitionService));
            _commandRouter = commandRouter ?? throw new ArgumentNullException(nameof(commandRouter));
        }

        /// <summary>
        ///     Populates the menu bar.
        /// </summary>
        /// <param name="menuBar">The <see cref="MenuBarDefinition"/>.</param>
        /// <param name="items">The root <see cref="MenuBarItemCollection"/>.</param>
        public void PopulateMenuBar(MenuBarDefinition menuBar, MenuBarItemCollection items)
        {
            var menus = _menuDefinitionService
                .GetMenusByMenuBar(new MenuBarDefinition())
                .OrderBy(menu => menu.SortOrder);

            foreach (var menu in menus)
            {
                var model = new Menu(menu);
                PopulateGroupsRecursive(menu, model);
                if (model.Children.Any())
                    items.Add(model);
            }
        }

        private void PopulateGroupsRecursive(MenuItemDefinition definition, MenuItem model)
        {
            if(definition == null || model == null)
                return;

            var groups = _menuDefinitionService.GetGroupsByParentMenuItem(definition)
                .ToList();

            for (var i = 0; i < groups.Count; i++)
            {
                var group = groups[i];
                var groupItems = _menuDefinitionService
                    .GetSubMenuItemsByGroup(group)
                    .OrderBy(groupItem => groupItem.SortOrder)
                    .ToList();

                foreach (var groupItem in groupItems)
                {
                    MenuItem menuItemModel = null;
                    switch (groupItem)
                    {
                        case TextMenuItemDefinition textMenuItem:
                            menuItemModel = new TextMenuItem(textMenuItem);
                            break;
                        case CommandMenuItemDefinition commandMenuItem:
                            //menuItemModel = new CommandMenuItem(commandMenuItem, _commandRouter.CreateRoutedCommand(null));
                            break;
                        default:
                            continue;
                    }

                    PopulateGroupsRecursive(groupItem, menuItemModel);

                    model.Children.Add(menuItemModel);
                }

                if (i < groups.Count - 1 && groupItems.Any())
                    model.Children.Add(new MenuItemSeparator());
            }
        }
    }
}
