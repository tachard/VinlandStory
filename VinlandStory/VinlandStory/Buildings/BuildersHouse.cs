using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class BuildersHouse : Building
    {
        public static readonly int __BUILDERSHOUSE_LENGTH = 1;
        public static readonly int __BUILDERSHOUSE_WIDTH = 1;
        public static readonly Resources __BUILDERSHOUSE_COST = new Resources(20, 5, 0);
        public static readonly int __BUILDERSHOUSE_RADIUS = 8;
        public static readonly int __BUILDERSHOUSE_WORKERS = 2;

        public BuildersHouse(int x, int y, Longhouse longhouse) : base(x, y, __BUILDERSHOUSE_LENGTH, __BUILDERSHOUSE_WIDTH, __BUILDERSHOUSE_COST, __BUILDERSHOUSE_RADIUS, __BUILDERSHOUSE_WORKERS, longhouse)
        {

        }
    }
}

