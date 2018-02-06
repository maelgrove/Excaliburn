#region

using System;
using Excaliburn.ComponentModel.Commands;

#endregion

namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents the definition of a command menu item. Command menu items can be used to
    ///     invoke commands from a menu item.
    /// </summary>
    /// <typeparamref name="TCommandDefinition">The type of the command definition.</typeparamref>
    public class CommandMenuItemDefinition<TCommandDefinition> : CommandMenuItemDefinition
        where TCommandDefinition : CommandDefinition
    {
        /// <inheritdoc />
        public override Type CommandDefinitionType { get; } = typeof(TCommandDefinition);

        /// <summary>
        ///     Creates a new <see cref="CommandMenuItemDefinition{TCommandDefinition}" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        public CommandMenuItemDefinition(MenuItemGroupDefinition group, int sortOrder = 0)
            : base(group, sortOrder)
        {
        }
    }

    /// <summary>
    ///     Represents the definition of a command menu item. Command menu items can be used to
    ///     invoke commands from a menu item.
    /// </summary>
    public abstract class CommandMenuItemDefinition : MenuItemDefinition
    {
        /// <summary>
        ///     Returns the type contract of the associated command definition.
        /// </summary>
        public abstract Type CommandDefinitionType { get; }

        /// <summary>
        ///     Creates a new <see cref="CommandMenuItemDefinition" />.
        /// </summary>
        /// <param name="group">The parent <see cref="MenuItemGroupDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        internal CommandMenuItemDefinition(MenuItemGroupDefinition group, int sortOrder = 0)
            : base(group, sortOrder)
        {
        }
    }
}
