using System;
using System.ComponentModel;
using System.Windows.Input;
using Excaliburn.Core.Input;

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents an <see cref="ICommand"/> which allows binding the execution and state of
    ///     a command to UI elements.
    /// </summary>
    public class CommandBinding : Command
    {
        private readonly CommandDefinition          _commandDefinition;
        private readonly ICommandHandlerResolver    _commandHandlerResolver;

        /// <summary>
        ///     Returns the <see cref="Commands.CommandState"/> associated with the command.
        /// </summary>
        public CommandState CommandState { get; }

        /// <summary>
        ///     Returns whether the command is enabled.
        /// </summary>
        public bool IsEnabled => CommandState.IsEnabled;

        /// <summary>
        ///     Returns whether the command is visible.
        /// </summary>
        public bool IsVisible => CommandState.IsVisible;

        /// <summary>
        ///     Returns whether the command is checked.
        /// </summary>
        public bool IsChecked => CommandState.IsChecked;

        /// <summary>
        ///     Returns the display text associated with the command.
        /// </summary>
        public string Text => CommandState.Text;

        /// <summary>
        ///     Returns the tooltip associated with the command.
        /// </summary>
        public string ToolTip => CommandState.ToolTip;

        /// <summary>
        ///     Returns the <see cref="Uri"/> of an icon source associated with the command.
        /// </summary>
        public Uri IconSource => CommandState.IconSource;


        public CommandBinding(CommandDefinition commandDefinition, CommandState commandState, ICommandHandlerResolver commandHandlerResolver)
        {
            _commandDefinition          = commandDefinition ?? throw new ArgumentNullException(nameof(commandDefinition));
            _commandHandlerResolver     = commandHandlerResolver ?? throw new ArgumentNullException(nameof(commandDefinition));
            CommandState                = commandState ?? throw new ArgumentNullException(nameof(commandState));
            CommandState.PropertyChanged += CommandStateOnPropertyChanged;
        }

        /// <inheritdoc />
        public override bool CanExecute(object parameter = default(object))
        {
            var handler = _commandHandlerResolver.GetCommandHandler(_commandDefinition.CommandHandlerType);
            handler.UpdateCommand(CommandState);
            return CommandState.IsEnabled;
        }

        /// <inheritdoc />
        public override async void Execute(object parameter = default(object))
        {
            if(!CommandState.IsEnabled)
                return;
            var handler = _commandHandlerResolver.GetCommandHandler(_commandDefinition.CommandHandlerType);
            await handler.ExecuteCommandAsync(CommandState);
        }

        /// <inheritdoc />
        public override event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private void CommandStateOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            // refresh the state of the binding if the command state might have changed
            Refresh();
        }
    }
}
