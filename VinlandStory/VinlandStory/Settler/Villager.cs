using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    public class Villager : Settler
    {
        public static readonly double __VILLAGER_BASE_BIRTH_RATE = 0.4;
        public static readonly double __VILLAGER_BASE_DEATH_RATE = 0.2;
        public static readonly double __VILLAGER_HUNGRY_BIRTH_RATE = 0;
        public static readonly double __VILLAGER_HUNGRY_DEATH_RATE = 0.6;

        public Villager(int x, int y, Building origin, World world) : base(x, y, __VILLAGER_BASE_BIRTH_RATE, __VILLAGER_BASE_DEATH_RATE, origin, world) { }
        /// <summary>
        /// Make villager eat. If no, villager may die.
        /// </summary>
        public void Eat(bool hasEaten)
        {
            _hunger = !hasEaten;
            if (_hunger)
            {
                Birth = __VILLAGER_HUNGRY_BIRTH_RATE;
                Death = __VILLAGER_HUNGRY_DEATH_RATE;
            }
            else
            {
                Birth = __VILLAGER_BASE_BIRTH_RATE;
                Death = __VILLAGER_BASE_DEATH_RATE;
            }
        }
        public override void SetNewGoal() { }
    }
}
