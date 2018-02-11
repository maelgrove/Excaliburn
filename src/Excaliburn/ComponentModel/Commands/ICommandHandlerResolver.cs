using System;

namespace Excaliburn.ComponentModel.Commands
{
    public interface ICommandHandlerResolver
    {
        ICommandHandler GetCommandHandler(Type commandHandlerType);
    }
}
