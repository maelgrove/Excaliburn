#region

using System;
using System.Windows.Input;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a generic definition of an executable operation within the composition
    ///     model of the framework. Command definitions serve as unique & strongly-typed identifiers
    ///     for commands and can be linked to associated command handlers, menu items or hotkeys.
    /// </summary>
    /// <typeparam name="TCommandHandler">
    ///     The type of the associated command handler, implementing <see cref="ICommandHandler" />.
    /// </typeparam>
    public abstract class CommandDefinition<TCommandHandler> : CommandDefinition
        where TCommandHandler : ICommandHandler
    {
        /// <inheritdoc />
        public sealed override Type CommandHandlerType { get; } = typeof(TCommandHandler);
    }

    /// <summary>
    ///     Represents a definition of an executable operation within the composition
    ///     model of the framework. Command definitions serve as unique & strongly-typed identifiers
    ///     for commands and can be linked to associated command handlers, menu items or hotkeys.
    /// </summary>
    public abstract class CommandDefinition
    {
        /// <summary>
        ///     Returns the type contract of the command handler associated with the definition.
        /// </summary>
        public abstract Type CommandHandlerType { get; }

        /// <summary>
        ///     Returns the default display text associated with the command.
        /// </summary>
        public virtual string Text => GetType().ToString();

        /// <summary>
        ///     Returns the default tooltip associated with the command.
        /// </summary>
        public virtual string ToolTip => Text;

        /// <summary>
        ///     Returns the <see cref="Uri" /> of the default icon associated with the command.
        /// </summary>
        public virtual Uri IconSource { get; } = null;

        /// <summary>
        ///     Creates a new <see cref="CommandDefinition" />.
        /// </summary>
        internal CommandDefinition()
        {
            // internal to prevent inheritance of this type
        }
    }
}
