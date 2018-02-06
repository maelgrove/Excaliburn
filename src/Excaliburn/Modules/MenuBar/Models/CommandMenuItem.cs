#region

using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MenuBar.Models
{
    // TODO
    public class CommandMenuItem : MenuItem<CommandMenuItemDefinition>
    {
        public CommandMenuItem(CommandMenuItemDefinition definition)
            : base(definition)
        {
        }
    }
}
