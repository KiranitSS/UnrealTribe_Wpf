using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.Materials
{
    public class Stick : Material
    {
        public Stick() : base()
        {
            this.Name = "Stick";
            this.Weight = 1;
            this.IsCountable = true;
        }
    }
}
