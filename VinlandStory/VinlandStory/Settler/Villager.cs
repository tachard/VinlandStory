using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Villager : Settler
    {
        public static readonly int __VILLAGER_VELOCITY = 1;
        public static readonly double __VILLAGER_BASE_BIRTH_RATE = 0.4;
        public static readonly double __VILLAGER_BASE_DEATH_RATE = 0.2;
        public static readonly double __VILLAGER_HUNGRY_BIRTH_RATE = 0;
        public static readonly double __VILLAGER_HUNGRY_DEATH_RATE = 0.6;

        public Villager(int x, int y, Building origin) : base(x, y, __VILLAGER_VELOCITY, __VILLAGER_BASE_BIRTH_RATE, __VILLAGER_BASE_DEATH_RATE, null, origin) { }

        public bool IsHungry()
        {
            if (_hunger)
            {
                this.setBirth(__VILLAGER_HUNGRY_BIRTH_RATE);
                this.setDeath(__VILLAGER_HUNGRY_DEATH_RATE);
            }
            else
            {
                this.setBirth(__VILLAGER_BASE_BIRTH_RATE);
                this.setDeath(__VILLAGER_BASE_DEATH_RATE);
            }
            return _hunger;
        }
    }
}
