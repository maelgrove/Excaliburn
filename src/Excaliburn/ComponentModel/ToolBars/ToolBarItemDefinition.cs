#region

using System;

#endregion

namespace Excaliburn.ComponentModel.ToolBars
{
    /// <summary>
    ///     Represents a base type for a definition of an item within the toolbar.
    /// </summary>
    public abstract class ToolBarItemDefinition
    {
        /// <summary>
        ///     Returns the parent toolbar item group of the item.
        /// </summary>
        public ToolBarItemGroupDefinition Group { get; }

        /// <summary>
        ///     Returns the sort order of the item.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="ToolBarItemGroupDefinition" />.
        /// </summary>
        /// <param name="group">The parent toolbar item group of the item.</param>
        /// <param name="sortOrder">Optional sort order of the item (defaults to 0).</param>
        protected ToolBarItemDefinition(ToolBarItemGroupDefinition group, int sortOrder = 0)
        {
            Group = group ?? throw new ArgumentNullException(nameof(group));
            SortOrder = sortOrder;
        }
    }
}
