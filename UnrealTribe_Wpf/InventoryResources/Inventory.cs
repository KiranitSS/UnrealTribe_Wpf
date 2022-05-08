using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnrealTribe.InventoryResources.Items.Materials;
using UnrealTribe_Wpf.InventoryResources;

namespace UnrealTribe.InventoryResources
{
    public class Inventory
    {
        /// <summary>
        /// A collection that contains inventory objects types and their count.
        /// </summary>
        public ObservableCollection<AdaptedToViewInventoryItem> Items { get; }

        /// <summary>
        /// Gets the element with the specified name.
        /// </summary>
        /// <param name="name">The name of the item to get.</param>
        /// <returns>Returns the element with the specified name.</returns>
        /// <exception cref="NullReferenceException">Throws if there no such elements.</exception>
        public AdaptedToViewInventoryItem this[string name]
        {
            get
            {
                if (name != null && this.Items.Any(i => i.Name == name))
                {
                    return this.Items[this.Items.IndexOf(this.Items.Single(i => i.Name == name))];
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public InventoryView View { get; }

        public Inventory()
        {
            this.Items = new ObservableCollection<AdaptedToViewInventoryItem>();
            this.View = new InventoryView();
        }

        public Inventory(ObservableCollection<AdaptedToViewInventoryItem> inventoryItems)
        {
            this.Items = inventoryItems;
            this.View = new InventoryView();
        }

        public void Add(Item item, int count)
        {
            if (!this.Items.Any(i => i.Name == item.Name))
            {
                this.Items.Add(new AdaptedToViewInventoryItem(item, count));
            }
            else
            {
                this[item.Name].Count += count;
            }
        }

        public void Take(Item item, int count)
        {
            if (this.Items.Any(i => i.Name == item.Name) || this[item.Name].Count < count)
            {
                this[item.Name].Count -= count;
            }
            else
            {
                if (item.IsCountable)
                {
                    MessageBox.Show($"Not enough {item}s");
                }
                else
                {
                    MessageBox.Show($"Not enough {item}");
                }
            }
        }

        public List<Item> GetAllItems()
        {
            return this.Items.Select(i => i.Item).ToList();
        }
    }
}
