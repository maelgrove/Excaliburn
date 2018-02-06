#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a generic base implementation of a <see cref="ICommandListSource" /> with
    ///     strongly-typed command state.
    /// </summary>
    /// <typeparam name="TCommandState">The state of the command, inheriting from <see cref="CommandState" />.</typeparam>
    public abstract class CommandListSource<TCommandState> : ICommandListSource
        where TCommandState : CommandState
    {
        /// <inheritdoc />
        IEnumerable<CommandState> ICommandListSource.CreateCommandStates() => CreateCommandStates();

        /// <inheritdoc />
        Task ICommandListSource.SelectCommandAsync(CommandState commandState)
        {
            if (commandState == null)
                throw new ArgumentNullException(nameof(commandState));
            if (!(commandState is TCommandState))
                throw new ArgumentException($@"Invalid command state '{commandState.GetType()}'. " +
                                            $@"Expected '{typeof(TCommandState)}'.", nameof(commandState));
            return SelectCommandAsync((TCommandState) commandState);
        }

        /// <summary>
        ///     Creates an enumeration of command states which are being used
        ///     to populate the list of commands.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}" /> of command states.</returns>
        public abstract IEnumerable<TCommandState> CreateCommandStates();

        /// <summary>
        ///     Asynchronously triggers the selection of a command using the specified command state.
        /// </summary>
        /// <param name="commandState">The command state.</param>
        /// <returns>A <see cref="Task" /> representing the operation.</returns>
        public abstract Task SelectCommandAsync(TCommandState commandState);
    }
}
