using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources.Items.Materials
{
    public class Log : Material
    {
        public Log() : base()
        {
            this.Name = "Log";
            this.Weight = 3;
            this.IsCountable = true;
        }
    }
}
