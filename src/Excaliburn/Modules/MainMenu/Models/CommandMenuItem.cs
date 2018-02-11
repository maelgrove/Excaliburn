#region

using System;
using System.Windows.Input;
using Excaliburn.ComponentModel.Menus;
using Excaliburn.Core.Input;
using CommandBinding = Excaliburn.ComponentModel.Commands.CommandBinding;

#endregion

namespace Excaliburn.Modules.MainMenu.Models
{
    /// <summary>
    ///     Represents a command menu item.
    /// </summary>
    public class CommandMenuItem : MenuItem
    {
        private readonly CommandBinding _commandBinding;
        private readonly KeyGesture _keyGesture;

        /// <summary>
        ///     Returns a bindable command associated with the item.
        /// </summary>
        //public ICommand Command => _commandBinding;

        /// <summary>
        ///     Returns whether the item is currently enabled.
        /// </summary>
        public bool IsEnabled => _commandBinding.IsEnabled;

        /// <summary>
        ///     Returns whether the item is currently visible and accessible from the UI.
        /// </summary>
        public bool IsVisible => _commandBinding.IsVisible;

        /// <summary>
        ///     Returns whether the item is currently in a checked state.
        /// </summary>
        public bool IsChecked => _commandBinding.IsChecked;

        /// <summary>
        ///     Returns the input gesture text associated with the item.
        /// </summary>
        public string InputGestureText => _keyGesture.GetDisplayString();

        /// <summary>
        ///     Returns the display text of the item.
        /// </summary>
        public override string Text => _commandBinding.Text;

        /// <summary>
        ///     Returns the tooltip of the item.
        /// </summary>
        public string ToolTip => _commandBinding.ToolTip;

        /// <summary>
        ///     Returns the <see cref="Uri"/> of an icon associated with the item.
        /// </summary>
        public Uri IconSource => _commandBinding.IconSource;

        /// <summary>
        ///     Creates a new <see cref="CommandMenuItem"/> using the specified <see cref="CommandMenuItemDefinition"/>
        ///     and a <see cref="CommandBinding"/>.
        /// </summary>
        /// <param name="definition">The <see cref="CommandMenuItemDefinition"/>.</param>
        /// <param name="commandBinding">The <see cref="CommandBinding"/>.</param>
        public CommandMenuItem(CommandMenuItemDefinition definition, CommandBinding commandBinding)
            : base(definition)
        {
            _commandBinding = commandBinding ?? throw new ArgumentNullException(nameof(commandBinding));
        }
    }
}
