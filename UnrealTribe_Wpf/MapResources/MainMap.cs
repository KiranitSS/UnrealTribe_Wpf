using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnrealTribe.MapResources;

namespace UnrealTribe.MapResources
{
    public class MainMap : Map
    {
        private readonly Random random = new Random(DateTime.Now.Millisecond);

        private readonly List<CellTypes> cellTypes = new List<CellTypes>();

        private readonly RiversCreator riversCreator;

        private readonly ObjectsCreator objectsCreator;

        public CampCoordinates CampCoordinates { get; }

        public int RiversCount { get; init; }

        public int MaxRiversLength { get; init; }

        public int BerryBushesCount { get; init; }

        public event EventHandler? NearCellClicked;

        public int CellClicksCounter { get; set; } = 0;

        public int MaxAvaibleClicksCount { get; set; } = 1;

        private int CellSize { get; } = 25;

        public MainMap(int height, int width) : base(height, width)
        {
            this.CampCoordinates = new CampCoordinates(random.Next(0, height), random.Next(0, width));
            this.riversCreator = new RiversCreator(this.Cells);
            this.objectsCreator = new ObjectsCreator(this.Cells);
            SetDefaultCellTypes();
            this.RiversCount = 0;
        }

        private void SetDefaultCellTypes()
        {
            this.cellTypes.AddRange(Enum.GetValues<CellTypes>());
        }

        public override void FillMap()
        {
            this.CreateCells();

            this.objectsCreator.CreateObjects(CellTypes.Forest, 400);
            this.objectsCreator.CreateObjects(CellTypes.Rocks, 300);
            this.objectsCreator.CreateObjects(CellTypes.Berry, 60);
            this.riversCreator.CreateObjects(this.RiversCount, MaxRiversLength);
        }


        public Cell CreateDefaultCell(int cellSize, int heightBooster, int widthBooster)
        {
            Cell cell = new Cell(CellTypes.Badland)
            {
                Width = cellSize,
                Height = cellSize,
                Margin = new Thickness(cellSize * widthBooster, cellSize * heightBooster, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                X = widthBooster,
                Y = heightBooster,
            };

            this.SetCellsClick(cell);

            return cell;
        }

        public override void SetCamp()
        {
            this.Cells[this.CampCoordinates.CampY, this.CampCoordinates.CampX].ChangeCellType(CellTypes.Camp);
            this.Cells[this.CampCoordinates.CampY, this.CampCoordinates.CampX].IsAvaible = true;
            this.Cells[this.CampCoordinates.CampY, this.CampCoordinates.CampX].IsOpened = true;
        }

        public override void OpenCamp()
        {
            this.SetCamp();
        }

        private void CreateCells()
        {
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.Cells[y, x] = this.CreateDefaultCell(this.CellSize, y, x);
                }
            }
        }

        private void SetCellsClick(Cell cell)
        {
            cell.Click += OnCellClick;
        }

        private void OnCellClick(object? sender, EventArgs e)
        {
            if (!this.IsAvaibleCellClick())
            {
                return;
            }

            if (sender is Cell cell)
            {
                this.OpenCell(cell);
            }

            if (this.NearCellClicked != null)
            {
                this.NearCellClicked.Invoke(sender, e);
            }
        }

        private void OpenCell(Cell cell)
        {

            if (cell.IsAvaible)
            {
                return;
            }

            if (this.IsNearbyAvaibleCell(cell))
            {
                this.Tools.OpenCell(cell);
                cell.IsAvaible = true;
                this.CellClicksCounter++;
            }
        }

        private bool IsAvaibleCellClick()
        {
            return this.CellClicksCounter < this.MaxAvaibleClicksCount;
        }

        private bool IsNearbyAvaibleCell(Cell cell)
        {
#pragma warning disable S108
            Cell cellForCheck;
            try
            {
                cellForCheck = this.Cells[cell.Y, cell.X - 1];

                if (IsAvaibleCell(cellForCheck))
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                cellForCheck = this.Cells[cell.Y, cell.X + 1];

                if (IsAvaibleCell(cellForCheck))
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                cellForCheck = this.Cells[cell.Y + 1, cell.X];

                if (IsAvaibleCell(cellForCheck))
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                cellForCheck = this.Cells[cell.Y - 1, cell.X];

                if (IsAvaibleCell(cellForCheck))
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
#pragma warning restore S108
            return false;
        }

        private bool IsAvaibleCell(Cell cell)
        {
            return cell.IsAvaible && !cell.IsRiver();
        }
    }
}
