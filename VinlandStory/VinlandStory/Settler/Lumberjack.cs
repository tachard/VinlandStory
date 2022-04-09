using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Lumberjack : Settler
    {
        public static readonly int __LUMBER_VELOCITY = 1;
        public static readonly double __LUMBER_BIRTH_RATE = 0;
        public static readonly double __LUMBER_DEATH_RATE = 0;
        public static readonly int __LUMBER_MAX_WOOD_WEARABLE = 400;

        private int _wood;
        private int _maxWood;

        public Lumberjack(int x, int y, Building origin) : base(x, y, __LUMBER_VELOCITY, __LUMBER_BIRTH_RATE, __LUMBER_DEATH_RATE, null, origin)
        {
            _wood = 0;
            _maxWood = __LUMBER_MAX_WOOD_WEARABLE;
        }

        public int getWood()
        {
            return _wood;
        }
        public void setWood(int nvWood)
        {
            _wood = nvWood;
        }
        /// <summary>
        /// Check if lumberjack is full of wood
        /// </summary>
        /// <returns>true if full</returns>
        public bool isFull()
        {
            return (_wood == _maxWood);
        }
        /// <summary>
        /// Collect a certain amount of wood
        /// </summary>
        /// <param name="numberWood">Number of collected wood</param>
        /// <returns>true if collected</returns>
        public bool cutWood(int numberWood)
        {
            if (isFull())  
            {
               return false;
            }
            else
            {
                //TO DO : revise this (case of partial full)
                setWood(getWood()+numberWood);
                return true;
            }
        }
    }
}
