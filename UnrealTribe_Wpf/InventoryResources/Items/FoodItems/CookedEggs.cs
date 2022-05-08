using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.FoodItems
{
    public class CookedEggs : Food
    {
        public CookedEggs() : base()
        {
            this.Name = "CookedEggs";
            this.Weight = 0.1f;
        }
    }
}
