using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.MapResources
{
    public class DirectionUtils
    {
        private readonly int mapHeigth;

        private readonly int mapWidth;

        private Random random = new Random();

        public DirectionUtils(int mapHeigth, int mapWidth)
        {
            this.mapHeigth = mapHeigth;
            this.mapWidth = mapWidth;
        }

        public Tuple<Direction, bool> RandCorrectDirection(Cell cell, int actionLength)
        {
            Direction direction = Direction.Up;

            int criticalDirectionsChecksCount = 100;

            for (int i = 0; i <= criticalDirectionsChecksCount; i++)
            {
                direction = GetRandomDirection();

                if (IsAvaibleDirection(cell, direction, actionLength))
                {
                    break;
                }

                if (i == criticalDirectionsChecksCount)
                {
                    return new(direction, false);
                }
            }
            return new(direction, true);
        }

        public bool IsAvaibleDirection(Cell cell, Direction direction, int actionLength)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (cell.Y - actionLength <= 0)
                    {
                        return false;
                    }
                    break;
                case Direction.Down:
                    if (cell.Y + actionLength >= this.mapHeigth)
                    {
                        return false;
                    }
                    break;
                case Direction.Left:
                    if (cell.X - actionLength <= 0)
                    {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (cell.X + actionLength >= this.mapWidth)
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }

        public Direction GetRandomDirection()
        {
            return (Direction)random.Next((int)Direction.Up, (int)Direction.Right);
        }
    }
}
