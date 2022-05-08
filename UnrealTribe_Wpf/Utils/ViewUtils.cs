using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UnrealTribe_Wpf.Utils
{
    public static class ViewUtils
    {
        public static int ScreenHeigth
        {
            get
            {
                return (int)SystemParameters.PrimaryScreenWidth;
            }
        }

        public static int ScreenHeight
        {
            get
            {
                return (int)SystemParameters.PrimaryScreenHeight;
            }
        }

        public static void SetDefaultFont(Window window)
        {
            string defaultFontName = "Comic Sans MS";
            int defaultFontSize = 16;
            window.FontFamily = new FontFamily(defaultFontName);
            window.FontSize = defaultFontSize;
        }
    }
}
