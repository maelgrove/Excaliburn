namespace Excaliburn.ComponentModel.Menus
{
    /// <summary>
    ///     Represents a base type for all menu item definitions within the composition model of the framework.
    /// </summary>
    public abstract class MenuItemDefinition
    {
        /// <summary>
        ///     Returns the sort order of the item.
        /// </summary>
        public int SortOrder { get; }

        /// <summary>
        ///     Creates a new <see cref="MenuItemDefinition" />.
        /// </summary>
        /// <param name="sortOrder">Optional sort order (defaults to 0).</param>
        internal MenuItemDefinition(int sortOrder = 0)
        {
            SortOrder = sortOrder;
        }
    }
}
