using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UnrealTribe_Wpf.Utils;

namespace UnrealTribe.MapResources
{
    public class Cell : Button, ICell
    {
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string wayBack = @"\..\..\..\";
        private readonly string targetFolder = @"\Images\Cells\";
        private readonly Random random = new Random();

        private readonly Dictionary<CellTypes, string> imagesNames = new Dictionary<CellTypes, string>()
        {
            { CellTypes.Berry, "Bush.png"},
            { CellTypes.Camp, "Camp.png"},
            { CellTypes.Field, "Field.png"},
            { CellTypes.Forest, "Forest.png"},
            { CellTypes.Rocks, "Rocks.png"},
            { CellTypes.Badland, "BadLand.png"},
        };

        private readonly string[] verticalImagesNames = new string[]
        {
            "VerticalRiver1.png",
            "VerticalRiver2.png",
            "VerticalRiver3.png",
        };

        private readonly string[] horizontalImagesNames = new string[]
        {
            "HorizontalRiver1.png",
            "HorizontalRiver2.png",
            "HorizontalRiver3.png",
        };

        public CellTypes CellType { get; private set; }

        public bool IsAvaible { get; set; }

        public bool IsOpened { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell()
        {
            this.BorderThickness = new Thickness(0, 0, 0, 0);
            this.imagesNames[CellTypes.VerticalRiver] = RandomVerticalRiverImage();
            this.imagesNames[CellTypes.HorizontalRiver] = RandomHorizontalRiverImage();
        }

        public Cell(CellTypes type) : this()
        {
            this.ChangeCellType(type);
        }

        public void ChangeCellType(CellTypes type)
        {
            if (type != CellTypes.Hidden)
            {
                TransformTo(type);
            }
            else
            {
                TransformToHidden();
            }
        }

        public void TransformTo(CellTypes type)
        {
            this.Background = GetImage(imagesNames[type]);
            this.CellType = type;
        }

        public void TransformToRiver(Direction direction)
        {
            string riverImageName = "River.png";

            switch (direction)
            {
                case Direction.Up:
                case Direction.Down:
                    this.CellType = CellTypes.VerticalRiver;
                    riverImageName = imagesNames[CellTypes.VerticalRiver];
                    break;
                case Direction.Right:
                case Direction.Left:
                    this.CellType = CellTypes.HorizontalRiver;
                    riverImageName = imagesNames[CellTypes.HorizontalRiver];
                    break;
            }

            this.Background = GetImage(riverImageName);
        }

        public void TransformToHidden()
        {
            this.Background = Brushes.DarkGreen;
        }

        public bool IsRiver()
        {
            if (this.CellType == CellTypes.HorizontalRiver || this.CellType == CellTypes.VerticalRiver)
            {
                return true;
            }

            return false;
        }

        private ImageBrush GetImage(string imageName)
        {
            return new ImageBrush(ImageUtils.GetFromFile(currentDirectory + wayBack + targetFolder + imageName));
        }

        private string RandomVerticalRiverImage()
        {
            return this.verticalImagesNames[random.Next(this.verticalImagesNames.Length)];
        }

        private string RandomHorizontalRiverImage()
        {
            return this.horizontalImagesNames[random.Next(this.horizontalImagesNames.Length)];
        }
    }
}
