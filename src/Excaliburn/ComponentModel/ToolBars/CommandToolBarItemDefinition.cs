#region

using System;
using Excaliburn.ComponentModel.Commands;

#endregion

namespace Excaliburn.ComponentModel.ToolBars
{
    // TODO

    /// <summary>
    ///     Represents the definition of a command toolbar item. Command toolbar items can be used to
    ///     invoke commands from a toolbar item.
    /// </summary>
    /// <typeparam name="TCommandDefinition">
    ///     The type contract of the command definition, inheriting from
    ///     <see cref="CommandDefinition" />.
    /// </typeparam>
    public class CommandToolBarItemDefinition<TCommandDefinition> : CommandToolBarItemDefinition
        where TCommandDefinition : CommandDefinition
    {
        /// <inheritdoc />
        public sealed override Type CommandDefinitionType { get; } = typeof(TCommandDefinition);

        /// <summary>
        ///     Creates a new <see cref="CommandToolBarItemDefinition{TCommandDefinition}" />.
        /// </summary>
        /// <param name="group">The parent toolbar item group of the item.</param>
        /// <param name="sortOrder">Optional sort order of the item (defaults to 0).</param>
        public CommandToolBarItemDefinition(ToolBarItemGroupDefinition group, int sortOrder = 0)
            : base(group, sortOrder)
        {
        }
    }

    /// <summary>
    ///     Represents the definition of a command toolbar item. Command toolbar items can be used to
    ///     invoke commands from a toolbar item.
    /// </summary>
    public abstract class CommandToolBarItemDefinition : ToolBarItemDefinition
    {
        /// <summary>
        ///     Returns the type contract of the associated <see cref="CommandDefinition" />.
        /// </summary>
        public abstract Type CommandDefinitionType { get; }

        /// <summary>
        ///     Creates a new <see cref="CommandToolBarItemDefinition" />.
        /// </summary>
        /// <param name="group">The parent toolbar item group of the item.</param>
        /// <param name="sortOrder">Optional sort order of the item (defaults to 0).</param>
        internal CommandToolBarItemDefinition(ToolBarItemGroupDefinition group, int sortOrder = 0)
            : base(group, sortOrder)
        {
        }
    }
}
