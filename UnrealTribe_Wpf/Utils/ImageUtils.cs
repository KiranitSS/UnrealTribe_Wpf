using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace UnrealTribe_Wpf.Utils
{
    public static class ImageUtils
    {
        public static BitmapImage GetFromFile(string imagePath)
        {
            return new BitmapImage(new Uri(imagePath));
        }
    }
}
