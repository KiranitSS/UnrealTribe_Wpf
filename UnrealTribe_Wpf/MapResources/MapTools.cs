using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.MapResources
{
    public class MapTools
    {
        private Map Map { get; }

        public MapTools(Map Map)
        {
            this.Map = Map;
            this.CellsTypes = new CellTypes[0, 0];
        }

        public CellTypes[,] CellsTypes { get; set; }

        public void HideMap()
        {
            if (this.Map != null)
            {
                var cells = this.Map.Cells;
                this.GetCellsTypes(cells);
                this.HideCells(cells);
            }
        }

        public void OpenMap()
        {
            if (Map != null)
            {
                var cells = this.Map.Cells;

                for (int y = 0; y < cells.GetLength(0); y++)
                {
                    for (int x = 0; x < cells.GetLength(1); x++)
                    {
                        cells[y, x].ChangeCellType(this.CellsTypes[y, x]);
                    }
                }
            }
        }

        public void OpenCell(Cell cell)
        {
            cell.ChangeCellType(this.CellsTypes[cell.Y, cell.X]);
        }

        private void GetCellsTypes(Cell[,] cells)
        {
            this.CellsTypes = new CellTypes[cells.GetLength(0), cells.GetLength(1)];

            for (int y = 0; y < cells.GetLength(0); y++)
            {
                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    this.CellsTypes[y, x] = cells[y, x].CellType;
                }
            }
        }

        private void HideCells(Cell[,] cells)
        {
            foreach (var cell in cells)
            {
                cell.ChangeCellType(CellTypes.Hidden);
            }
        }
    }
}
