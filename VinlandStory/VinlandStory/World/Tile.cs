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
        public int X { get; private set; }
        public int Y { get; private set; }

        public Tile(Resources availableMin, Resources availableMax, Random alea, int x, int y)
        {
            AvailableMin = availableMin;
            AvailableMax = availableMax;
            Available = new Resources(alea.Next(AvailableMin.Wood, AvailableMax.Wood + 1),
                alea.Next(AvailableMin.Stone, AvailableMax.Stone + 1),
                alea.Next(AvailableMin.Food, AvailableMax.Food + 1));
            X = x;
            Y = y;
        }
        /// <summary>
        /// Print a tile with a certain foreground, blackground color and character (utf-8 needed)
        /// </summary>
        public abstract void PrintTile();
    }
}
