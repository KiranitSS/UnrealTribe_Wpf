using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.FoodItems
{
    public class Pumpkin : Food
    {
        public Pumpkin() : base()
        {
            this.Name = "Pumpkin";
            this.Weight = 5;
            this.IsCountable = true;
        }
    }
}
