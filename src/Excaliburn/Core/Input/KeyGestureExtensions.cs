using System.Globalization;
using System.Windows.Input;

namespace Excaliburn.Core.Input
{
    /// <summary>
    ///     Provides extensions for <see cref="KeyGesture" />.
    /// </summary>
    public static class KeyGestureExtensions
    {
        /// <summary>
        ///     Returns the display string of the specified <see cref="KeyGesture" /> for the current UI culture (
        ///     <see cref="CultureInfo.CurrentUICulture" />).
        /// </summary>
        /// <param name="keyGesture">The <see cref="KeyGesture" />.</param>
        /// <returns>The display string for the current UI culture, or <see cref="string.Empty" />.</returns>
        public static string GetDisplayString(this KeyGesture keyGesture) =>
            keyGesture?.GetDisplayStringForCulture(CultureInfo.CurrentUICulture)
            ?? string.Empty;
    }
}
