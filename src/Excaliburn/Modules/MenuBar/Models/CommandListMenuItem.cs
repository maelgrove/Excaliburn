#region

using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MenuBar.Models
{
    internal class CommandListMenuItem : MenuItem<CommandListMenuItemDefinition>
    {
        public CommandListMenuItem(CommandListMenuItemDefinition definition)
            : base(definition)
        {
        }
    }
}
