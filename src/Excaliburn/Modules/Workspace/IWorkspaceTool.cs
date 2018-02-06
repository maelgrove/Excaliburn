namespace Excaliburn.Modules.Workspace
{
    /// <summary>
    ///     Represents a specialized <see cref="T:Excaliburn.Modules.Workspace.IWorkspaceItem" /> which is being loaded into
    ///     the
    ///     as anchorable into the workspace, and can provide additional tools for a current
    ///     <see cref="T:Excaliburn.Modules.Workspace.IWorkspaceDocument" />.
    /// </summary>
    public interface IWorkspaceTool : IWorkspaceItem
    {
        /// <summary>
        ///     Returns the preferred <see cref="WorkspaceToolAlignment" /> of the tool.
        /// </summary>
        WorkspaceToolAlignment PreferredAlignment { get; }

        /// <summary>
        ///     Returns the preferred width of the tool.
        /// </summary>
        double PreferredWidth { get; }

        /// <summary>
        ///     Returns the preferred height of the tool.
        /// </summary>
        double PreferredHeight { get; }

        /// <summary>
        ///     Gets or sets whether the tool is currently visible.
        /// </summary>
        bool IsVisible { get; set; }
    }
}
