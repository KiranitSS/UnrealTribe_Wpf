using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UnrealTribe_Wpf.Utils
{
    public static class ColorsUtils
    {
        private static readonly string defaultButtonColor = "#FFDDDDDD";
        public static Brush DefaultButtonColor { get; } = new SolidColorBrush(GetColorFromHex(defaultButtonColor));

        private static Color GetColorFromHex(string hex)
        {
            return (Color)ColorConverter.ConvertFromString(hex);
        }
    }
}
