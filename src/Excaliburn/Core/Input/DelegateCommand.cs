#region

using System;
using System.Windows.Input;

#endregion

namespace Excaliburn.Core.Input
{
    /// <summary>
    ///     Represents a <see cref="DelegateCommand{TParameter}" /> with standard object parameter.
    /// </summary>
    public class DelegateCommand : DelegateCommand<object>
    {
        /// <inheritdoc />
        public DelegateCommand(Action execute, Func<bool> canExecute = null)
            : base(execute, canExecute)
        {
        }

        /// <inheritdoc />
        public DelegateCommand(Action<object> execute, Func<bool> canExecute = null) : base(execute, canExecute)
        {
        }

        /// <inheritdoc />
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null) : base(execute, canExecute)
        {
        }
    }

    /// <summary>
    ///     Represents a generic <see cref="ICommandEx" /> with strongly-typed parameters which
    ///     relays the execution to a delegate.
    /// </summary>
    /// <typeparam name="TParameter">The type of the parameter.</typeparam>
    public class DelegateCommand<TParameter> : Command<TParameter>
    {
        private readonly Func<TParameter, bool> _canExecute;
        private readonly Action<TParameter> _execute;

        /// <inheritdoc />
        public DelegateCommand(Action execute, Func<bool> canExecute = null)
            : this(parameter => execute.Invoke(), parameter => canExecute?.Invoke() ?? true)
        {
        }

        /// <inheritdoc />
        public DelegateCommand(Action<TParameter> execute, Func<bool> canExecute = null)
            : this(execute, parameter => canExecute?.Invoke() ?? true)
        {
        }

        /// <summary>
        ///     Creates a new <see cref="DelegateCommand{TParameter}" />.
        /// </summary>
        /// <param name="execute">The action delegate to execute.</param>
        /// <param name="canExecute">The function delegate to validate the execution.</param>
        public DelegateCommand(Action<TParameter> execute, Func<TParameter, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc />
        public override event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <inheritdoc />
        public override bool CanExecute(TParameter parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <inheritdoc />
        public override void Execute(TParameter parameter) => _execute.Invoke(parameter);
    }
}
