namespace Excaliburn.Themes
{
    /// <summary>
    ///     Represents a service for loading <see cref="ITheme" />s.
    /// </summary>
    public interface IThemeService
    {
        /// <summary>
        ///     Returns the currently loaded <see cref="ITheme" />.
        /// </summary>
        ITheme CurrentTheme { get; }

        /// <summary>
        ///     Loads the specified <see cref="ITheme" />.
        /// </summary>
        /// <param name="theme">The <see cref="ITheme" /> to load.</param>
        void LoadTheme(ITheme theme);
    }
}
