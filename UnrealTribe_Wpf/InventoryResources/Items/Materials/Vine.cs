using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.Materials
{
    public class Vine : Material
    {
        public Vine() : base()
        {
            this.Name = "Vine";
            this.Weight = 0.5f;
            this.IsCountable = true;
        }
    }
}
