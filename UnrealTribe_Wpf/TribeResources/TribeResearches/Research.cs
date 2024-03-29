﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealTribe.InventoryResources;

namespace UnrealTribe.TribeResources.TribeResearches
{
    public abstract class Research
    {
        protected Research()
        {
            this.Name = string.Empty;
            this.ItemsOnResearch = Array.Empty<InventoryItem>();
        }

        protected Research(string name, int timeToComplite, InventoryItem[] itemsOnResearch)
        {
            this.Name = name;
            this.TurnsToComplite = timeToComplite;
            this.ItemsOnResearch = itemsOnResearch;
        }

        public string Name { get; }

        public int TurnsToComplite { get; protected set; }
        public int RemainingTurns { get; protected set; }
        
        public InventoryItem[] ItemsOnResearch { get; protected set; }

        public bool IsComplited { get; set; }
    }
}
