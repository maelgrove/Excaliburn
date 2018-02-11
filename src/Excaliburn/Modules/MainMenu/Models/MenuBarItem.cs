#region

#endregion

using Caliburn.Micro;
using Excaliburn.ComponentModel.Menus;

namespace Excaliburn.Modules.MainMenu.Models
{
    /// <summary>
    ///     Represents a base type for all items within the <see cref="IMenuBar" />.
    /// </summary>
    public abstract class MenuBarItem : PropertyChangedBase
    {
        private MenuItem _parent;

        /// <summary>
        ///     Returns the parent <see cref="TextMenuItem" /> of this item.
        /// </summary>
        public MenuItem Parent
        {
            get => _parent;
            internal set
            {
                Set(ref _parent, value);
                NotifyOfPropertyChange(nameof(IsTopLevelItem));
            }
        }

        /// <summary>
        ///     Returns whether the current item is a top level item in the menu bar.
        /// </summary>
        public bool IsTopLevelItem => Parent == null;
    }
}
