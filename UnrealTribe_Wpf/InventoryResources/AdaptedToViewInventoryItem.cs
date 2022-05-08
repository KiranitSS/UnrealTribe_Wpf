using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealTribe.InventoryResources;

namespace UnrealTribe_Wpf.InventoryResources
{
    public class AdaptedToViewInventoryItem
    {
        private int count;

        public Item Item { get; }

        public string Name { get => Item.Name; }

        public float Weight { get => Item.Weight; }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
                this.TotalWeight = this.Weight * this.count;
            }
        }

        public float TotalWeight { get; private set; }

        public AdaptedToViewInventoryItem (Item item, int count = 1)
        {
            this.Item = item;
            this.Count = count;
            this.TotalWeight = this.Weight * count;
        }

        public override bool Equals(object? obj)
        {
            if (obj is AdaptedToViewInventoryItem adapteditem)
            {
                return this.Item.Equals(adapteditem.Item);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(AdaptedToViewInventoryItem adaptedItem)
        {
            if (adaptedItem != null)
            {
                return this.Item.Equals(adaptedItem.Item);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Item.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
