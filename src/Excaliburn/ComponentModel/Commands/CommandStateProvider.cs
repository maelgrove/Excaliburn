using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents the default <see cref="ICommandStateProvider"/> implementation.
    /// </summary>
    internal class CommandStateProvider : ICommandStateProvider
    {
        private readonly Dictionary<Type, CommandState> _commandStates = new Dictionary<Type, CommandState>();
        private readonly ILog _log = LogManager.GetLog(typeof(CommandStateProvider));

        /// <inheritdoc />
        public CommandState GetOrCreateCommandState(CommandDefinition commandDefinition)
        {
            if (commandDefinition == null)
                throw new ArgumentNullException(nameof(commandDefinition));
            var commandDefinitionType = commandDefinition.GetType();
            if (!_commandStates.TryGetValue(commandDefinitionType, out var commandState))
            {
                _commandStates.Add(commandDefinitionType, commandState = new CommandState
                {
                    // assign defaults
                    Text = commandDefinition.Text,
                    ToolTip = commandDefinition.ToolTip,
                    IconSource = commandDefinition.IconSource
                });
            }

            return commandState;
        }
    }
}
