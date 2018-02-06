#region

using System;

#endregion

namespace Excaliburn.ComponentModel.ToolBars
{
    /// <summary>
    ///     Represents the definition of a group of tool bar items within a toolbar.
    /// </summary>
    public class ToolBarItemGroupDefinition
    {
        /// <summary>
        ///     Returns the parent toolbar of the group.
        /// </summary>
        public ToolBarDefinition ToolBar { get; }

        /// <summary>
        ///     Returns the sort order of the toolbar item group.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="ToolBarItemGroupDefinition" />.
        /// </summary>
        /// <param name="toolBar">The parent toolbar of the group.</param>
        /// <param name="sortOrder">Optional sort order of the toolbar item group (defaults to 0).</param>
        public ToolBarItemGroupDefinition(ToolBarDefinition toolBar, int sortOrder = 0)
        {
            ToolBar = toolBar ?? throw new ArgumentNullException(nameof(toolBar));
            SortOrder = sortOrder;
        }
    }
}
