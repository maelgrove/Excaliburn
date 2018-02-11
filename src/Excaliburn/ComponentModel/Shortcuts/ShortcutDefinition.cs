using System;
using System.Windows.Input;
using Excaliburn.ComponentModel.Commands;

namespace Excaliburn.ComponentModel.Shortcuts
{
    /// <summary>
    ///     Represents a generic <see cref="ShortcutDefinition" /> with strongly-typed command definition.
    /// </summary>
    /// <typeparam name="TCommandDefinition">
    ///     The type contract of the command definition, implementing
    ///     <see cref="CommandDefinition" />.
    /// </typeparam>
    public class ShortcutDefinition<TCommandDefinition> : ShortcutDefinition
        where TCommandDefinition : CommandDefinition
    {
        /// <inheritdoc />
        public override Type CommandDefinitionType { get; } = typeof(TCommandDefinition);

        /// <inheritdoc />
        public ShortcutDefinition(KeyGesture keyGesture, int sortOrder = 0)
            : base(keyGesture, sortOrder)
        {
        }
    }

    /// <summary>
    ///     Represents the definition of a keyboard shortcut within the composition model of the framework. 
    ///     A keyboard shortcut is a series of one or several keys which can be registered to invoke an associated 
    ///     command via its <see cref="CommandDefinition" />. Multiple keyboard shortcuts can be registered for a 
    ///     single command, however in menus and toolbars, only the primary keyboard shortcut for a command is being 
    ///     displayed, which is being determined by the <see cref="SortOrder" /> of the shortcut.
    /// </summary>
    public abstract class ShortcutDefinition
    {
        /// <summary>
        ///     Returns the type contract of the <see cref="CommandDefinition" /> associated with the stortcut.
        /// </summary>
        public abstract Type CommandDefinitionType { get; }

        /// <summary>
        ///     Returns the <see cref="System.Windows.Input.KeyGesture" /> of the shortcut.
        /// </summary>
        public KeyGesture KeyGesture { get; }

        /// <summary>
        ///     Returns the sort order of the shortcut.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="ShortcutDefinition" />.
        /// </summary>
        /// <param name="keyGesture">The <see cref="System.Windows.Input.KeyGesture" /> of the shortcut.</param>
        /// <param name="sortOrder">Optional sort order of the shortcut (default to 0).</param>
        internal ShortcutDefinition(KeyGesture keyGesture, int sortOrder = 0)
        {
            KeyGesture = keyGesture ?? throw new ArgumentNullException(nameof(keyGesture));
            SortOrder = sortOrder;
        }
    }
}
