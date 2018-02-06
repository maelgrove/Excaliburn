#region

using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

#endregion

namespace Excaliburn.Windows
{
    /// <summary>
    ///     Represents a base implementation of <see cref="T:Excaliburn.Windows.IWindow" />.
    /// </summary>
    public abstract class Window : Screen, IWindow
    {
        private double _height = 600;
        private ImageSource _icon;
        private double _left;
        private WindowState _state = WindowState.Normal;
        private double _top;
        private double _width = 800;

        /// <inheritdoc />
        public WindowState State
        {
            get => _state;
            set => Set(ref _state, value);
        }

        /// <inheritdoc />
        public double Width
        {
            get => _width;
            set => Set(ref _width, value);
        }

        /// <inheritdoc />
        public double Height
        {
            get => _height;
            set => Set(ref _height, value);
        }

        /// <inheritdoc />
        public double Top
        {
            get => _top;
            set => Set(ref _top, value);
        }

        /// <inheritdoc />
        public double Left
        {
            get => _left;
            set => Set(ref _left, value);
        }

        /// <inheritdoc />
        public ImageSource Icon
        {
            get => _icon;
            set => Set(ref _icon, value);
        }
    }
}
