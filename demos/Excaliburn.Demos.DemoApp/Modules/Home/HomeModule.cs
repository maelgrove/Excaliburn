#region

using Excaliburn.ComponentModel.Menus;
using Excaliburn.Demos.DemoApp.Modules.Home.Commands;

#endregion

namespace Excaliburn.Demos.DemoApp.Modules.Home
{
    public class HomeModule
    {
        public static MenuItemGroupDefinition HelloWorldMenuItemGroup = new MenuItemGroupDefinition();

        public static CommandMenuItemDefinition<HelloWorldCommandDefinition> HelloWorldCommandMenuItem
            = new CommandMenuItemDefinition<HelloWorldCommandDefinition>(HelloWorldMenuItemGroup);
    }
}
