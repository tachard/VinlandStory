using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    abstract class Tile
    {
        public Resources Available { get; set; }
        public Resources AvailableMin { get; private set; }
        public Resources AvailableMax { get; private set; }

        public Tile(Resources availableMin, Resources availableMax, Random alea)
        {
            AvailableMin = availableMin;
            AvailableMax = availableMax;
            Available = new Resources(alea.Next(AvailableMin.Wood, AvailableMax.Wood + 1),
                alea.Next(AvailableMin.Stone, AvailableMax.Stone + 1),
                alea.Next(AvailableMin.Food, AvailableMax.Food + 1));
        }

        public abstract void PrintTile();
    }
}
