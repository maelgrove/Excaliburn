namespace Excaliburn.ComponentModel.ToolBars
{
    /// <summary>
    ///     Represents a definition of a toolbar. Toolbars either provide
    ///     document-specific or application-wide tools, depending on how they are being declared.
    /// </summary>
    public class ToolBarDefinition
    {
        /// <summary>
        ///     Returns the sort order of the toolbar.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="ToolBarDefinition" />.
        /// </summary>
        /// <param name="sortOrder">Optional sort order of the toolbar (defaults to 0).</param>
        public ToolBarDefinition(int sortOrder = 0)
        {
            SortOrder = sortOrder;
        }
    }
}
