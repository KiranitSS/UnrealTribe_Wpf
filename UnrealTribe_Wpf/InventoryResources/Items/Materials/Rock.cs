using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.Materials
{
    public class Rock : Material
    {
        public Rock() : base()
        {
            this.Name = "Rock";
            this.Weight = 0.5f;
            this.IsCountable = true;
        }
    }
}
