using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class Mine : Building
    {
        public static readonly int __MINE_LENGTH = 1;
        public static readonly int __MINE_WIDTH = 1;
        public static readonly Resources __MINE_COST = new Resources(5, 20, 0);
        public static readonly int __MINE_RADIUS = 5;
        public static readonly int __MINE_WORKERS = 2;

        public Mine(int x, int y, Longhouse longhouse) : base(x, y, __MINE_LENGTH, __MINE_WIDTH, __MINE_COST, __MINE_RADIUS, __MINE_WORKERS, longhouse)
        {

        }
    }
}
