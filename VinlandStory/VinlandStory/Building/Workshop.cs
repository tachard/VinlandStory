using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    public class Workshop : Building
    {
        public static readonly int __WORKSHOP_LENGTH = 1;
        public static readonly int __WORKSHOP_WIDTH = 1;
        public static readonly Resources __WORKSHOP_COST = new Resources(20, 5, 0);
        public static readonly int __WORKSHOP_RADIUS = 5;
        public static readonly int __WORKSHOP_WORKERS = 2;

        public Workshop(int x, int y, Longhouse longhouse) : base(x, y, __WORKSHOP_LENGTH, __WORKSHOP_WIDTH, __WORKSHOP_COST, __WORKSHOP_RADIUS, __WORKSHOP_WORKERS, longhouse)
        {

        }
    }
}
