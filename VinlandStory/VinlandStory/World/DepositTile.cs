using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class DepositTile:Tile
    {
        private static readonly Resources __DEPOSIT_RESOURCES_MIN = new Resources(0, 150, 0);
        private static readonly Resources __DEPOSIT_RESOURCES_MAX = new Resources(0, 150, 0);

        public DepositTile(Random alea) : base(__DEPOSIT_RESOURCES_MIN, __DEPOSIT_RESOURCES_MAX, alea) { }

        public override void PrintTile()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Δ");
        }
    }
}
