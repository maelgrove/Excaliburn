namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents the definition of a group of menu items. Menu item groups are
    ///     used for grouping individual menu items (see <see cref="MenuItemDefinition" />) and
    ///     put them in a hierarchical structure through nesting them within text menus. If a group
    ///     has no parent text menu item definition declared, it acts as a top level group.
    /// </summary>
    public class MenuItemGroupDefinition
    {
        /// <summary>
        ///     Returns the parent <see cref="TextMenuItemDefinition" /> of the group.
        /// </summary>
        public TextMenuItemDefinition Parent { get; }

        /// <summary>
        ///     Returns whether this is a definition for a top level group.
        /// </summary>
        public bool IsTopLevelGroup => Parent == null;

        /// <summary>
        ///     Returns the sort order of the group.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuItemGroupDefinition" />.
        /// </summary>
        /// <param name="parent">Optional parent <see cref="TextMenuItemDefinition" />.</param>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        public MenuItemGroupDefinition(TextMenuItemDefinition parent = null, int sortOrder = 0)
        {
            Parent = parent;
            SortOrder = sortOrder;
        }
    }
}
