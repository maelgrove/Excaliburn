#region

using System;
using System.Collections.Generic;

#endregion

namespace Excaliburn.Themes
{
    /// <summary>
    ///     Represents a theme which provides resources for the appearance of the UI.
    /// </summary>
    public interface ITheme
    {
        /// <summary>
        ///     Returns the display name of the theme.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Returns an enumeration of <see cref="Uri" />s of resources to load within the theme.
        /// </summary>
        IEnumerable<Uri> ApplicationResources { get; }
    }
}
