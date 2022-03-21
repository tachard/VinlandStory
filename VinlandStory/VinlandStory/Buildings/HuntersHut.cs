using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class HuntersHut : Building
    {
        public static readonly int __HUT_LENGTH = 1;
        public static readonly int __HUT_WIDTH = 1;
        public static readonly Resources __HUT_COST = new Resources(10, 10, 0);
        public static readonly int __HUT_RADIUS = 8;
        public static readonly int __HUT_WORKERS = 2;

        public HuntersHut(int x, int y) : base(x,y,__HUT_LENGTH,__HUT_WIDTH,__HUT_COST, __HUT_RADIUS, __HUT_WORKERS)
        {

        }
    }
}
