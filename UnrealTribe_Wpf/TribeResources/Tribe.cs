using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealTribe.InventoryResources;
using UnrealTribe.TribeResources.TribeResearches;
using UnrealTribe_Wpf.InventoryResources;

namespace UnrealTribe.TribeResources
{
    public class Tribe
    {
        public TribeInfo TribalInfo { get; }

        public Researches Reserches { get; }

        public Inventory Inventory { get; }

        public Tribe()
        {
            this.TribalInfo = new TribeInfo();
            this.Reserches = new Researches();
            this.Inventory = new Inventory();
        }
    }
}
