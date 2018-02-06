#region

using System;
using Excaliburn.ComponentModel.Commands;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a generic <see cref="CommandListMenuItemDefinition" /> with strongly-typed command list source.
    /// </summary>
    /// <typeparam name="TCommandListSource">
    ///     The type contract of the command list source, implementing <see cref="ICommandListSource" />
    /// </typeparam>
    public class CommandListMenuItemDefinition<TCommandListSource> : CommandListMenuItemDefinition
        where TCommandListSource : ICommandListSource
    {
        /// <inheritdoc />
        public override Type CommandListSourceType { get; } = typeof(TCommandListSource);

        /// <summary>
        ///     Creates a new <see cref="CommandMenuItemDefinition{TCommandDefinition}" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        public CommandListMenuItemDefinition(MenuItemGroupDefinition group, int sortOrder = 0)
            : base(group, sortOrder)
        {
        }
    }

    /// <summary>
    ///     Represents the definition of a command list menu item. Command list menu items
    ///     provide a list of commands which are dynamically populated during runtime.
    /// </summary>
    public abstract class CommandListMenuItemDefinition : MenuItemDefinition
    {
        /// <summary>
        ///     Returns the type contract of the associated command list source.
        /// </summary>
        public abstract Type CommandListSourceType { get; }

        /// <summary>
        ///     Creates a new <see cref="CommandMenuItemDefinition" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        internal CommandListMenuItemDefinition(MenuItemGroupDefinition group, int sortOrder = 0)
            : base(group, sortOrder)
        {
        }
    }
}
