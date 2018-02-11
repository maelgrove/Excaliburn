using System;
using System.Collections.Generic;

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents the default <see cref="ICommandStateCache"/> implementation.
    /// </summary>
    internal class CommandStateCache : ICommandStateCache
    {
        private readonly Dictionary<Type, CommandState> _commandStates = new Dictionary<Type, CommandState>();

        /// <inheritdoc />
        public CommandState GetOrCreateCommandState(CommandDefinition commandDefinition)
        {
            if (commandDefinition == null)
                throw new ArgumentNullException(nameof(commandDefinition));
            var commandDefinitionType = commandDefinition.GetType();
            if (!_commandStates.TryGetValue(commandDefinitionType, out var commandState))
                _commandStates.Add(commandDefinitionType, commandState = new CommandState(commandDefinition));

            return commandState;
        }
    }
}
