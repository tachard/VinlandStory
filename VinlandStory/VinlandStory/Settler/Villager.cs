using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Villager : Settler
    {
        public static readonly int __VILLAGER_VELOCITY = 1;
        public static readonly double __VILLAGER_BIRTH_RATE = 0.2;
        public static readonly double __VILLAGER_DEATH_RATE = 0.15;

        public Villager(int x, int y) : base (x, y, __VILLAGER_VELOCITY, __VILLAGER_BIRTH_RATE, __VILLAGER_DEATH_RATE) { }
    }
}
