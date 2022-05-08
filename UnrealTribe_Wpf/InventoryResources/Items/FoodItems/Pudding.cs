using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.FoodItems
{
    public class Pudding : Food
    {
        public Pudding() : base()
        {
            this.Name = "Pudding";
            this.Weight = 1;
            this.IsCountable = true;
        }
    }
}
