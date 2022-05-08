using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UnrealTribe.InventoryResources;
using UnrealTribe.InventoryResources.Items.Materials;
using UnrealTribe.MapResources;
using UnrealTribe_Wpf.Utils;

namespace UnrealTribe_Wpf.InventoryResources
{
    public partial class InventoryView : Window
    {
        private readonly static string imagesPath = @"\..\..\..\Images\";
        private readonly string calendarBackgroundPath = Directory.GetCurrentDirectory() + imagesPath + @"Backgrounds\InventoryBackground.jpg";
        private readonly int widthBonus = 200;

        public Inventory Inventory { get; }
        private readonly GridView inventoryView = new GridView();

        public InventoryView()
        {
            InitializeComponent();

            this.SetInventoryBackground();

            this.Inventory = new Inventory();
            this.InventoryItemsLv.ItemsSource = this.Inventory.Items;

            this.InstallDefaultInventoryView();

            this.Width = this.InventoryItemsLv.Width + widthBonus;
        }

        public void OnMapCellClicked(object? sender, EventArgs e)
        {
            if (sender is Cell cell)
            {
                if (!cell.IsOpened)
                {
                    this.ClaimDefaultCellsItems(cell);
                    this.InventoryItemsLv.Items.Refresh();
                }
            }
        }

        private void ClaimDefaultCellsItems(Cell cell)
        {
            switch (cell.CellType)
            {
                case CellTypes.Berry:
                    break;
                case CellTypes.Field:
                    break;
                case CellTypes.Forest:
                    this.Inventory.Add(new Log(), 3);
                    this.Inventory.Add(new Stick(), 5);
                    this.Inventory.Add(new Vine(), 2);
                    break;
                case CellTypes.HorizontalRiver:
                case CellTypes.VerticalRiver:
                    break;
                case CellTypes.Rocks:
                    this.Inventory.Add(new Rock(), 3);
                    break;
                case CellTypes.Badland:
                    this.Inventory.Add(new Stick(), 1);
                    this.Inventory.Add(new Rock(), 1);
                    break;
            }

            cell.IsOpened = true;
        }

        private void InstallDefaultInventoryView()
        {
            ViewUtils.SetDefaultFont(this);

            this.InventoryItemsLv.IsHitTestVisible = false;
            this.InventoryItemsLv.View = this.inventoryView;

            this.InstallHeaders();

            this.InstallDefaultCollumnsWidth();
        }

        private void InstallHeaders()
        {
            this.inventoryView.Columns.Add(new GridViewColumn()
            {
                Header = "Item",
                DisplayMemberBinding = new Binding("Name")
            });

            this.inventoryView.Columns.Add(new GridViewColumn()
            {
                Header = "Weight",
                DisplayMemberBinding = new Binding("Weight")
            });

            this.inventoryView.Columns.Add(new GridViewColumn()
            {
                Header = "Count",
                DisplayMemberBinding = new Binding("Count")
            });

            this.inventoryView.Columns.Add(new GridViewColumn()
            {
                Header = "Total weight",
                DisplayMemberBinding = new Binding("TotalWeight")
            });
        }

        private void InstallDefaultCollumnsWidth()
        {
            int columnWidth = (int)this.InventoryItemsLv.Width / this.inventoryView.Columns.Count;

            foreach (var column in this.inventoryView.Columns)
            {
                column.Width = columnWidth;
            }
        }

        private void SetInventoryBackground()
        {
            this.Background = new ImageBrush(ImageUtils.GetFromFile(this.calendarBackgroundPath));
        }

        private void TribeInventory_Leave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void RefillInventoryBySortedItems(AdaptedToViewInventoryItem[] items)
        {
            this.Inventory.Items.Clear();

            foreach (var item in items)
            {
                this.Inventory.Items.Add(item);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SortByNameBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = this.Inventory.Items.OrderBy(i => i.Name).ToArray();

            this.RefillInventoryBySortedItems(items);
        }

        private void SortByWeightBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = this.Inventory.Items.OrderBy(i => i.TotalWeight).ToArray();

            RefillInventoryBySortedItems(items);
        }
    }
}
