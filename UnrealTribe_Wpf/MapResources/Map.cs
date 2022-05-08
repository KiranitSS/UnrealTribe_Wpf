using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.MapResources
{
    public abstract class Map
    {
        public Cell[,] Cells { get; }

        public int Height { get; }

        public int Width { get; }

        public MapTools Tools { get; }

        private readonly int cellsSize;

        protected Map(int height, int width)
        {
            this.Tools = new MapTools(this);
            this.Height = height;
            this.Width = width; 
            this.Cells = new Cell[height, width];
        }

        protected Map(int height, int width, int cellSize) : this(height, width)
        {
            this.cellsSize = cellSize;
        }

        public abstract void FillMap();

        public abstract void SetCamp();

        public abstract void OpenCamp();
    }
}
