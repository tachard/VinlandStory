using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class Longhouse : Building
    {
        public static readonly int __LONGHOUSE_LENGTH = 3;
        public static readonly int __LONGHOUSE_WIDTH = 2;
        public static readonly int __INITIAL_SETTLERS = 15;

        public Longhouse(int x, int y) : base(x, y, __LONGHOUSE_LENGTH, __LONGHOUSE_WIDTH, new Resources(0,0,0),0,__INITIAL_SETTLERS)
        {

        }


    }
}
