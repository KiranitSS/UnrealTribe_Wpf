using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items
{
    public abstract class Material : InventoryItem
    {
        protected Material() : base()
        {
        }

        protected Material(string name, float weight) : base(name, weight)
        {
        }
    }
}
