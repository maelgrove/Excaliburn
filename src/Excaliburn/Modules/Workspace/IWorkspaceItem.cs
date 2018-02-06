#region

using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;

#endregion

namespace Excaliburn.Modules.Workspace
{
    /// <summary>
    ///     Represents a <see cref="IScreen" /> which can be loaded into the workspace
    ///     of an application. The workspace item is usually either a document, or a tool.
    /// </summary>
    public interface IWorkspaceItem : IScreen
    {
        /// <summary>
        ///     Returns the unique identifier of the item.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        ///     Returns the content id of the item.
        /// </summary>
        string ContentId { get; }

        /// <summary>
        ///     Returns a tooltip associated with the item.
        /// </summary>
        string ToolTip { get; }

        /// <summary>
        ///     Returns whether the item can float.
        /// </summary>
        bool CanFloat { get; }

        /// <summary>
        ///     Returns an <see cref="ICommand" /> which is being triggered for closing the item.
        /// </summary>
        ICommand CloseCommand { get; }

        /// <summary>
        ///     Returns the <see cref="Uri" /> of an icon associated with the item.
        /// </summary>
        Uri IconSource { get; }

        /// <summary>
        ///     Gets or sets whether the panel is currently item.
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        ///     Returns whether the item should be re-opened when the application starts.
        /// </summary>
        bool ShouldReopenOnStart { get; }

        /// <summary>
        ///     Asynchronously loads the state of the item using the specified <see cref="BinaryReader" />.
        /// </summary>
        /// <param name="reader">A <see cref="BinaryReader" /> for reading the state.</param>
        /// <returns>A <see cref="Task" /> representing the operation.</returns>
        Task LoadState(BinaryReader reader);

        /// <summary>
        ///     Asynchronously saves the state of the item using the specified <see cref="BinaryWriter" />.
        /// </summary>
        /// <param name="writer">A <see cref="BinaryWriter" /> for persisting the state.</param>
        /// <returns>A <see cref="Task" /> representing the operation.</returns>
        Task SaveState(BinaryWriter writer);
    }
}
