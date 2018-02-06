using System;

namespace Excaliburn.ComponentModel.Commands
{
    public interface ICommandService
    {
        CommandDefinition GetCommandDefinition(Type commandDefinitionType);
    }
}
