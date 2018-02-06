#region

using System;
using System.Windows.Input;
using Excaliburn.Core.Input;

#endregion

namespace Excaliburn.ComponentModel.Commands
{
    public class BindableCommand : Command
    {
        /// <inheritdoc />
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
        }

        /// <inheritdoc />
        public override event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
