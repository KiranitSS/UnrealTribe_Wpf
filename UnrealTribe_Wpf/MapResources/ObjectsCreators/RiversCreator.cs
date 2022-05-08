using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UnrealTribe.MapResources
{
    public class RiversCreator : IMapObjectsCreator
    {
        public Cell[,] Cells { get; }

        private readonly Random random = new Random();

        private readonly DirectionUtils directionUtils;

        private readonly int heigth;
        private readonly int width;

        public int MinObjectLength { get; set; }

        public RiversCreator(Cell[,] cells)
        {
            this.Cells = cells;
            this.heigth = cells.GetLength(0);
            this.width = cells.GetLength(1);
            this.directionUtils = new DirectionUtils(heigth, width);
            this.MinObjectLength = 3;
        }

        public void CreateObjects(int objectsCount)
        {
            int maxObjectLength = 1;

            for (int i = 0; i < objectsCount; i++)
            {
                if (!TryCreateRiver(maxObjectLength))
                {
                    break;
                }
            }
        }

        public void CreateObjects(int objectsCount = 0, int maxObjectLength = 0)
        {
            if (maxObjectLength > this.width || maxObjectLength > this.heigth || maxObjectLength < 0)
            {
                _ = MessageBox.Show("Can't create rivers. Incorrect rivers length.");
            }

            for (int i = 0; i < objectsCount; i++)
            {
                if (!TryCreateRiver(maxObjectLength))
                {
                    break;
                }
            }
        }

        private bool TryCreateRiver(int maxRiverLength)
        {
            int riverLength = random.Next(this.MinObjectLength, maxRiverLength);

            Cell cell;

            do
            {
                cell = ChooseRandomCell();
            }
            while (cell.CellType is CellTypes.Camp);

            var riverDirectionTuple = directionUtils.RandCorrectDirection(cell, riverLength);

            if (riverDirectionTuple.Item2 == false)
            {
                return false;
            }
            else
            {
                CreateRiver(cell, riverDirectionTuple.Item1, riverLength);
            }

            return true;
        }

        private void CreateRiver(Cell cell, Direction direction, int riverLength)
        {
            switch (direction)
            {
                case Direction.Up:
                    CreateRiverUp(cell, riverLength);
                    break;
                case Direction.Down:
                    CreateRiverDown(cell, riverLength);
                    break;
                case Direction.Left:
                    CreateRiverLeft(cell, riverLength);
                    break;
                case Direction.Right:
                    CreateRiverRight(cell, riverLength);
                    break;
            }
        }

        private void CreateRiverUp(Cell cell, int riverLength)
        {
            for (int i = 0; i < riverLength; i++)
            {
                this.Cells[cell.Y - i, cell.X].TransformToRiver(Direction.Up);
            }
        }

        private void CreateRiverDown(Cell cell, int riverLength)
        {
            for (int i = 0; i < riverLength; i++)
            {
                this.Cells[cell.Y + i, cell.X].TransformToRiver(Direction.Down);
            }
        }

        private void CreateRiverLeft(Cell cell, int riverLength)
        {
            for (int i = 0; i < riverLength; i++)
            {
                this.Cells[cell.Y, cell.X - i].TransformToRiver(Direction.Left);
            }
        }

        private void CreateRiverRight(Cell cell, int riverLength)
        {
            for (int i = 0; i < riverLength; i++)
            {
                this.Cells[cell.Y, cell.X + i].TransformToRiver(Direction.Right);
            }
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
