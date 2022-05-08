using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UnrealTribe_Wpf.Extensions
{
    public static class Extensions
    {
        public static ReadOnlyCollection<T> GetControls<T>(this Panel panel) where T : Control
        {
            UIElementCollection uiElement = panel.Children;

            List<FrameworkElement> elements = uiElement.Cast<FrameworkElement>().ToList();

            return new ReadOnlyCollection<T>(elements.OfType<Control>().OfType<T>().ToArray());
        }
    }
}
