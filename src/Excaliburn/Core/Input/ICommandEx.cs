#region

using System.Windows.Input;
using Caliburn.Micro;

#endregion

namespace Excaliburn.Core.Input
{
    /// <summary>
    ///     Represents an extended <see cref="ICommand" /> which allows subscribers to externally notify about a change
    ///     in whether a command can be executed.
    /// </summary>
    public interface ICommandEx : ICommand, INotifyPropertyChangedEx
    {
        /// <summary>Notifies subscribers of a change in whether the command can be executed.</summary>
        void NotifyOfCanExecuteChange();
    }
}
