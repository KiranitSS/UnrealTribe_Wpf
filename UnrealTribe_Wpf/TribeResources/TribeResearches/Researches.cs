using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealTribe_Wpf.TribeResources.TribeResearches;

namespace UnrealTribe.TribeResources.TribeResearches
{
    public class Researches
    {
        public Researches()
        {
            this.View = new ResearchesView();
        }

        public ResearchesView View { get; }
    }
}
