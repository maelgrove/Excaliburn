#region

using System;
using Caliburn.Micro;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents the state of a command during runtime, which can be persisted in order to
    ///     access it from various UI elements.
    /// </summary>
    /// <remarks>
    ///     Commands are enabled and visible by default.
    /// </remarks>
    public class CommandState : PropertyChangedBase
    {
        private Uri _iconSource;
        private bool _isChecked;
        private bool _isEnabled = true;
        private bool _isVisible = true;
        private string _text;
        private string _tooltip;

        /// <summary>
        ///     Gets or sets whether the command is currently enabled.
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        /// <summary>
        ///     Gets or sets whether the command is currently visible and accessible from the UI.
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set => Set(ref _isVisible, value);
        }

        /// <summary>
        ///     Gets or sets whether the command is currently in a checked state.
        /// </summary>
        public bool IsChecked
        {
            get => _isChecked;
            set => Set(ref _isChecked, value);
        }

        /// <summary>
        ///     Gets or sets the display text of the command.
        /// </summary>
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        /// <summary>
        ///     Gets or sets the tooltip associated with the command.
        /// </summary>
        public string ToolTip
        {
            get => _tooltip;
            set => Set(ref _tooltip, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="Uri" /> of the icon source associated with the command.
        /// </summary>
        public Uri IconSource
        {
            get => _iconSource;
            set => Set(ref _iconSource, value);
        }
    }
}
