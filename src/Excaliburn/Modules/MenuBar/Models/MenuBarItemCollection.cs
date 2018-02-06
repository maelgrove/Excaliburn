#region

using System.Collections.ObjectModel;
using System.Linq;
using Excaliburn.ComponentModel.Menus;

#endregion

namespace Excaliburn.Modules.MenuBar.Models
{
    /// <summary>
    ///     Represents an observable collection of <see cref="MenuBarItem" />s.
    /// </summary>
    public class MenuBarItemCollection : ObservableCollection<MenuBarItem>
    {
        private readonly TextMenuItem _owner;

        /// <summary>
        ///     Creates a new <see cref="MenuBarItemCollection" />.
        /// </summary>
        /// <param name="owner">The owner of the collection.</param>
        internal MenuBarItemCollection(TextMenuItem owner)
        {
            _owner = owner;
        }

        /// <inheritdoc />
        protected override void InsertItem(int index, MenuBarItem item)
        {
            if (Contains(item))
                return;
            item.Parent?.Children?.Remove(item);
            item.Parent = _owner;
            base.InsertItem(index, item);
        }

        /// <inheritdoc />
        protected override void RemoveItem(int index)
        {
            var item = this[index];
            item.Parent = null;
            base.RemoveItem(index);
        }

        /// <inheritdoc />
        protected override void SetItem(int index, MenuBarItem item)
        {
            var i = IndexOf(item);
            if (i >= 0 && i != index)
                return;
            var previous = this[index];
            previous.Parent = null;
            item.Parent = _owner;
            base.SetItem(index, item);
        }

        /// <summary>
        ///     Returns a menu item from the collection using the specified menu item definition.
        /// </summary>
        /// <typeparam name="TMenuItemDefinition">The type of the menu item definition to look up.</typeparam>
        /// <param name="definition">The menu item definition.</param>
        /// <returns>The menu item, if available.</returns>
        public MenuItem<TMenuItemDefinition> GetMenuItemByDefinition<TMenuItemDefinition>(
            TMenuItemDefinition definition)
            where TMenuItemDefinition : MenuItemDefinition => this.OfType<MenuItem<TMenuItemDefinition>>()
            .FirstOrDefault(x => x.Definition == definition);
    }
}
