using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.FoodItems
{
    public class Tomato : Food
    {
        public Tomato() : base()
        {
            this.Name = "Tomato";
            this.Weight = 0.1f;
            this.IsCountable = true;
        }
    }
}
