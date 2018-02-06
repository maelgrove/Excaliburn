#region

using System.Windows.Input;
using Excaliburn.Core.Input;

#endregion

namespace Excaliburn.Modules.Workspace
{
    /// <summary>
    ///     Represents a base implementation of a <see cref="IWorkspaceTool" />.
    /// </summary>
    public abstract class WorkspaceTool : WorkspaceItem, IWorkspaceTool
    {
        private ICommand _closeCommand;
        private bool _isVisible = true;

        /// <inheritdoc cref="IWorkspaceItem.CloseCommand" />
        public sealed override ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new DelegateCommand(p => IsVisible = false, p => true)); }
        }

        /// <inheritdoc />
        public virtual WorkspaceToolAlignment PreferredAlignment { get; } = WorkspaceToolAlignment.Left;

        /// <inheritdoc cref="IWorkspaceItem.ShouldReopenOnStart" />
        public override bool ShouldReopenOnStart { get; } = true;

        /// <inheritdoc />
        public virtual double PreferredWidth { get; } = 200;

        /// <inheritdoc />
        public virtual double PreferredHeight { get; } = 200;

        /// <inheritdoc />
        public bool IsVisible
        {
            get => _isVisible;
            set => Set(ref _isVisible, value);
        }
    }
}
