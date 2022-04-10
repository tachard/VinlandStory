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
        public static readonly double __LUMBER_BIRTH_RATE = 0;
        public static readonly double __LUMBER_DEATH_RATE = 0;
        public static readonly int __LUMBER_MAX_WOOD_WEARABLE = 400;

        private int _wood;
        private int _maxWood;

        public Lumberjack(int x, int y, Building origin) : base(x, y, __LUMBER_BIRTH_RATE, __LUMBER_DEATH_RATE, null, origin)
        {
            _wood = 0;
            _maxWood = __LUMBER_MAX_WOOD_WEARABLE;
        }

        public int Wood { get => _wood; set => _wood = value; }

        /// <summary>
        /// Check if lumberjack is full of wood
        /// </summary>
        /// <returns>true if full</returns>
        public bool IsFull()
        {
            return _wood == _maxWood;
        }
        /// <summary>
        /// Collect a certain amount of wood
        /// </summary>
        /// <param name="numberWood">Number of collected wood</param>
        /// <returns>number of wood cut</returns>
        public int CutWood(int numberWood)
        {
            if (IsFull())
            {
                return 0;
            }
            else
            {
                if (Wood + numberWood > _maxWood)
                {
                    int picked = _maxWood - Wood;
                    Wood = _maxWood;
                    return picked;
                }
                else
                {
                    Wood += numberWood;
                    return numberWood;
                }
            }
        }
    }
}
