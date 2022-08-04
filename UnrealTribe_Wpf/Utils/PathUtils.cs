using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe_Wpf.Utils
{
    internal static class PathUtils
    {
        private static string wayBack = @"\..\..\";
        public static string MusicFolder { get; } = "Music\\";
        public static string ImagesFolder { get; } = "Images\\";
        public static string MusicPath { get; } = Directory.GetCurrentDirectory() + wayBack + MusicFolder;
        public static string ImagesPath { get; } = Directory.GetCurrentDirectory() + wayBack + ImagesFolder;
    }
}
