using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class BuildingTile:Tile
    {
        private static readonly Resources __BUILDING_RESOURCES_MIN = new Resources(0, 0, 0);
        private static readonly Resources __BUILDING_RESOURCES_MAX = new Resources(0, 0, 0);

        public BuildingTile(Random alea) : base(__BUILDING_RESOURCES_MIN, __BUILDING_RESOURCES_MAX, alea) { }

        public override void PrintTile()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("⌂");
        }
    }
}
