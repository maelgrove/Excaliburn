#region

using System;
using System.Windows.Input;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents the definition of a hotkey for invoking a <see cref="CommandDefinition" /> using a
    ///     <see cref="KeyGesture" />.
    /// </summary>
    /// <typeparam name="TCommandDefinition">The type contract of the command definition.</typeparam>
    public class CommandKeyGesture<TCommandDefinition> : CommandKeyGesture
        where TCommandDefinition : CommandDefinition
    {
        /// <inheritdoc />
        public sealed override Type CommandDefinitionType => typeof(TCommandDefinition);

        /// <inheritdoc />
        public CommandKeyGesture(KeyGesture keyGesture, int sortOrder = 0)
            : base(keyGesture, sortOrder)
        {
        }
    }

    /// <summary>
    ///     Represents the definition of a hotkey for invoking a <see cref="CommandDefinition" /> using a
    ///     <see cref="System.Windows.Input.KeyGesture" />.
    /// </summary>
    public abstract class CommandKeyGesture
    {
        /// <summary>
        ///     Returns the type contract of the associated <see cref="CommandDefinition" />.
        /// </summary>
        public abstract Type CommandDefinitionType { get; }

        /// <summary>
        ///     Returns the <see cref="System.Windows.Input.KeyGesture" />.
        /// </summary>
        public KeyGesture KeyGesture { get; }

        /// <summary>
        ///     Returns the sort order of the key gesture.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="CommandKeyGesture" />.
        /// </summary>
        /// <param name="keyGesture">The <see cref="System.Windows.Input.KeyGesture" />.</param>
        /// <param name="sortOrder">Optional sort order of the gesture.</param>
        internal CommandKeyGesture(KeyGesture keyGesture, int sortOrder = 0)
        {
            KeyGesture = keyGesture ?? throw new ArgumentNullException(nameof(keyGesture));
            SortOrder = sortOrder;
        }
    }
}
