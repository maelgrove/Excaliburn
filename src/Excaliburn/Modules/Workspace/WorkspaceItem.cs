#region

using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;

#endregion

namespace Excaliburn.Modules.Workspace
{
    /// <summary>
    ///     Represents a base implementation of a <see cref="IWorkspaceItem" />.
    /// </summary>
    public abstract class WorkspaceItem : Screen, IWorkspaceItem
    {
        private bool _canFloat = true;
        private Uri _iconSource;
        private bool _isSelected;
        private string _tooltip;

        /// <inheritdoc />
        [Browsable(false)]
        public Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        [Browsable(false)]
        public string ContentId => Id.ToString();

        /// <inheritdoc />
        public virtual string ToolTip
        {
            get => _tooltip ?? DisplayName;
            protected set => Set(ref _tooltip, value);
        }

        /// <inheritdoc />
        public virtual bool CanFloat
        {
            get => _canFloat;
            protected set => Set(ref _canFloat, value);
        }

        /// <inheritdoc />
        public abstract ICommand CloseCommand { get; }

        /// <inheritdoc />
        public virtual Uri IconSource
        {
            get => _iconSource;
            protected set => Set(ref _iconSource, value);
        }

        /// <inheritdoc />
        public virtual bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

        /// <inheritdoc />
        public virtual bool ShouldReopenOnStart { get; } = false;

        /// <inheritdoc />
        public virtual Task LoadState(BinaryReader reader) => Task.CompletedTask;

        /// <inheritdoc />
        public Task SaveState(BinaryWriter writer) => Task.CompletedTask;
    }
}
