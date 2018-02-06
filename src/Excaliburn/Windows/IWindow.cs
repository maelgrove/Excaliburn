#region

using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

#endregion

namespace Excaliburn.Windows
{
    /// <summary>
    ///     Represents an application window.
    /// </summary>
    public interface IWindow : IScreen
    {
        /// <summary>
        ///     Gets or sets the <see cref="WindowState" /> of the window.
        /// </summary>
        WindowState State { get; set; }

        /// <summary>
        ///     Gets or sets the width of the window.
        /// </summary>
        double Width { get; set; }

        /// <summary>
        ///     Gets or sets the height of the window.
        /// </summary>
        double Height { get; set; }

        /// <summary>
        ///     Gets or sets the distance of the window from the left side of the screen.
        /// </summary>
        double Left { get; set; }

        /// <summary>
        ///     Gets or sets the distance of the window from the top side of the screen.
        /// </summary>
        double Top { get; set; }

        /// <summary>
        ///     Gets or sets the window icon as <see cref="ImageSource" />.
        /// </summary>
        ImageSource Icon { get; set; }
    }
}
