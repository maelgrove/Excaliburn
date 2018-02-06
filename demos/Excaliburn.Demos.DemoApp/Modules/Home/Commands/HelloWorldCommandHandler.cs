#region

using System.Threading.Tasks;
using Excaliburn.ComponentModel.Commands;

#endregion

namespace Excaliburn.Demos.DemoApp.Modules.Home.Commands
{
    /// <summary>
    ///     Represents the command handler of the 'Hello World' command, as defined by
    ///     the <see cref="HelloWorldCommandDefinition" />. This <see cref="ICommandHandler" /> provides
    ///     the execution logic for the command.
    /// </summary>
    public class HelloWorldCommandHandler : CommandHandler
    {
        /// <summary>
        ///     Updates the command using the specified <see cref="CommandState" />.
        /// </summary>
        /// <param name="commandState">The state of the command to update.</param>
        public override void UpdateCommand(CommandState commandState)
        {
            // TODO hello world -> exemplary update
        }

        /// <summary>
        ///     Asynchronously executes the command.
        /// </summary>
        /// <param name="commandState">The state of the command.</param>
        /// <returns>A <see cref="Task" /> representing the operation.</returns>
        public override Task ExecuteCommandAsync(CommandState commandState)
        {
            // TODO hello world -> exemplary execution
            return Task.CompletedTask;
        }
    }
}
