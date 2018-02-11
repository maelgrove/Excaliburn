#region

using System;
using System.Windows.Input;
using Caliburn.Micro;

#endregion

namespace Excaliburn.Core.Input
{
    /// <summary>
    ///     Represents an <see cref="Command{TParameter}" /> with standard object parameter.
    /// </summary>
    public abstract class Command : Command<object>
    {
    }

    /// <summary>
    ///     Represents a generic <see cref="ICommandEx" /> with strongly-typed command parameter.
    /// </summary>
    /// <typeparam name="TParameter">The type of the parameter.</typeparam>
    public abstract class Command<TParameter> : PropertyChangedBase, ICommandEx
    {
        private bool _canExecute = true;

        /// <inheritdoc />
        public virtual event EventHandler CanExecuteChanged;

        /// <inheritdoc cref="INotifyPropertyChangedEx.Refresh" />
        public override void Refresh()
        {
            NotifyOfPropertyChange(string.Empty);
            NotifyOfCanExecuteChange();
        }

        /// <inheritdoc />
        public virtual void NotifyOfCanExecuteChange()
        {
            if (!IsNotifying || CanExecuteChanged == null)
                return;
            OnUIThread(() => CanExecuteChanged.Invoke(this, EventArgs.Empty));
        }

        /// <inheritdoc />
        bool ICommand.CanExecute(object parameter)
        {
            parameter = parameter is TParameter ? parameter : default(TParameter);
            var canExecute = CanExecute((TParameter) parameter);
            if (_canExecute != canExecute)
                NotifyOfCanExecuteChange();
            return _canExecute = canExecute;
        }

        /// <inheritdoc />
        void ICommand.Execute(object parameter)
        {
            parameter = parameter is TParameter ? parameter : default(TParameter);
            if (!CanExecute((TParameter) parameter))
                return;
            Execute((TParameter) parameter);
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public virtual bool CanExecute(TParameter parameter = default(TParameter)) => true;

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to null.
        /// </param>
        public abstract void Execute(TParameter parameter = default(TParameter));
    }
}
