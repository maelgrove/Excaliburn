#region

using System.Collections.Generic;

#endregion

namespace Excaliburn.Modules.Workspace
{
    /// <summary>
    ///     Represents the workspace of the application.
    /// </summary>
    public interface IWorkspace
    {
        /// <summary>
        ///     Returns an enumeration of currently opened <see cref="IWorkspaceDocument" />s.
        /// </summary>
        IEnumerable<IWorkspaceDocument> Documents { get; }

        /// <summary>
        ///     Returns an enumeration of currently opened <see cref="IWorkspaceTool" />s.
        /// </summary>
        IEnumerable<IWorkspaceTool> Tools { get; }

        /// <summary>
        ///     Returns the currently selected <see cref="IWorkspaceDocument" />.
        /// </summary>
        IWorkspaceDocument SelectedDocument { get; }

        /// <summary>
        ///     Opens the specified <see cref="IWorkspaceDocument" />.
        /// </summary>
        /// <param name="document">The <see cref="IWorkspaceDocument" /> to open.</param>
        void OpenDocument(IWorkspaceDocument document);

        /// <summary>
        ///     Closes the specified <see cref="IWorkspaceDocument" />.
        /// </summary>
        /// <param name="document">The <see cref="IWorkspaceDocument" /> to close.</param>
        void CloseDocument(IWorkspaceDocument document);

        /// <summary>
        ///     Opens the specified <see cref="IWorkspaceTool" />.
        /// </summary>
        /// <param name="tool">The <see cref="IWorkspaceTool" /> to open.</param>
        void OpenTool(IWorkspaceTool tool);

        /// <summary>
        ///     Closes the specified <see cref="IWorkspaceTool" />.
        /// </summary>
        /// <param name="tool">The <see cref="IWorkspaceTool" /> to close.</param>
        void CloseTool(IWorkspaceTool tool);
    }
}
