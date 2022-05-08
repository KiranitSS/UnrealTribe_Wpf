using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UnrealTribe.MapResources
{
    public class ObjectsCreator
    {
        private readonly int heigth;
        private readonly int width;
        private readonly Random random = new Random();

        public ObjectsCreator(Cell[,] cells)
        {
            this.Cells = cells;
            this.heigth = cells.GetLength(0);
            this.width = cells.GetLength(1);
        }

        public Cell[,] Cells { get; set; }

        public int MinObjectLength { get; set; } = 1;

        public void CreateObjects(CellTypes objectType, int objectsCount = 0, int maxObjectLength = 1)
        {
            if (maxObjectLength < 0 || maxObjectLength > this.heigth || maxObjectLength > this.width)
            {
                _ = MessageBox.Show("Can't create berries. Incorrect berries bush length.");
            }

            for (int i = 0; i < objectsCount; i++)
            {
                this.CreateObject(objectType);
            }
        }

        private void CreateObject(CellTypes objectType)
        {
            int y = random.Next(this.heigth);
            int x = random.Next(this.width);
            this.Cells[y, x].TransformTo(objectType);
        }

        public Cell ChooseRandomCell()
        {
            int maxHigthBorder = this.heigth;
            int maxWidthBorder = this.width;
            int minBorder = 0;

            int yIndex = random.Next(minBorder, maxHigthBorder);
            int xIndex = random.Next(minBorder, maxWidthBorder);

            return this.Cells[yIndex, xIndex];
        }
    }
}
