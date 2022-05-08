using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.FoodItems
{
    public abstract class Food : Item
    {
        protected Food() : base()
        {
        }

        protected Food(string name, float weight) : base(name, weight)
        {
        }
    }
}
