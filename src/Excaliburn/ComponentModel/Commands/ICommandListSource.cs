#region

using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a service which provides a dynamically generated list of command
    ///     states and handles their execution on selection.
    /// </summary>
    public interface ICommandListSource
    {
        /// <summary>
        ///     Creates an enumeration of <see cref="CommandState" />s which are being used
        ///     to populate the list of commands.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}" /> of <see cref="CommandState" />.</returns>
        IEnumerable<CommandState> CreateCommandStates();

        /// <summary>
        ///     Asynchronously triggers the selection of a command using the specified
        ///     <see cref="CommandState" />.
        /// </summary>
        /// <param name="commandState">The <see cref="CommandState" />.</param>
        /// <returns>A <see cref="Task" /> representing the operation.</returns>
        Task SelectCommandAsync(CommandState commandState);
    }
}
