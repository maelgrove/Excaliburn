#region

using System.Threading.Tasks;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a service which handles the execution of a command defined by an
    ///     associated <see cref="CommandDefinition" />.
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        ///     Updates the command using the specified <see cref="CommandState" />.
        /// </summary>
        /// <param name="commandState">The state of the command to update.</param>
        void UpdateCommand(CommandState commandState);

        /// <summary>
        ///     Asynchronously executes the command.
        /// </summary>
        /// <param name="commandState">The state of the command.</param>
        /// <returns>A <see cref="Task" /> representing the operation.</returns>
        Task ExecuteCommandAsync(CommandState commandState);
    }
}
