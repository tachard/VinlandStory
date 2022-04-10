using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class MeadowTile : Tile
    {
        private static readonly Resources __MEADOW_RESOURCES_MIN = new Resources(0, 0, 100);
        private static readonly Resources __MEADOW_RESOURCES_MAX = new Resources(0, 0, 140);

        public MeadowTile(Random alea, int x, int y) : base(__MEADOW_RESOURCES_MIN, __MEADOW_RESOURCES_MAX, alea, x, y) { }

        public override void PrintTile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("_");
        }
    }
}
