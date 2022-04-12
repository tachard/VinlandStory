using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    public class ForestTile : Tile
    {
        private static readonly Resources __FOREST_RESOURCES_MIN = new Resources(100, 0, 25);
        private static readonly Resources __FOREST_RESOURCES_MAX = new Resources(150, 0, 40);

        public ForestTile(Random alea, int x, int y) : base(__FOREST_RESOURCES_MIN, __FOREST_RESOURCES_MAX, alea, x, y) { }

        public override void PrintTile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\u04AC");
        }
    }
}
