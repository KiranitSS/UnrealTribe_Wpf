using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.MapResources
{
    public class CampCoordinates
    {
        public CampCoordinates(int campY, int campX)
        {
            this.CampY = campY;
            this.CampX = campX;
        }

        public int CampY { get; set; }
        public int CampX { get; set; }
    }
}
