#region

using System.Threading.Tasks;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a base implementation of a <see cref="ICommandHandler" />.
    /// </summary>
    public abstract class CommandHandler : ICommandHandler
    {
        /// <inheritdoc />
        public virtual void UpdateCommand(CommandState commandState)
        {
        }

        /// <inheritdoc />
        public abstract Task ExecuteCommandAsync(CommandState commandState);
    }
}
