using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class MeadowTile:Tile
    {
        private static readonly Resources __MEADOW_RESOURCES_MIN = new Resources(0, 0, 40);
        private static readonly Resources __MEADOW_RESOURCES_MAX = new Resources(0, 0, 40);

        public MeadowTile(Random alea):base(__MEADOW_RESOURCES_MIN, __MEADOW_RESOURCES_MAX, alea) { }

        public override void PrintTile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("_");
        }
    }
}
