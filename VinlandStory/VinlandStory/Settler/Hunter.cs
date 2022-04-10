using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Hunter : Settler
    {
        public static readonly double __HUNTER_BIRTH_RATE = 0;
        public static readonly double __HUNTER_DEATH_RATE = 0;
        public static readonly int __HUNTER_MAX_FOOD_WEARABLE = 400;
        private int _food;
        private int _maxFood;

        public Hunter(int x, int y, Building origin) : base(x, y, __HUNTER_BIRTH_RATE, __HUNTER_DEATH_RATE, null, origin)
        {
            _food = 0;
            _maxFood = __HUNTER_MAX_FOOD_WEARABLE;
        }
        public int Food { get => _food; set => _food = value; }
        /// <summary>
        /// Check if hunter is full
        /// </summary>
        /// <returns>True if full</returns>
        public bool IsFull()
        {
            return (_food == _maxFood);
        }
        /// <summary>
        /// Collect Food. If complete, collect nothing.
        /// </summary>
        /// <param name="numberFood">Number of potentially picked food</param>
        /// <returns>Number of really collected food</returns>
        public int CollectFood(int numberFood)
        {
            if (IsFull())
            {
                return 0;
            }
            else
            {
                if (Food + numberFood > _maxFood)
                {
                    int picked = _maxFood - Food;
                    Food = _maxFood;
                    return picked;
                }
                else
                {
                    Food += numberFood;
                    return numberFood;
                }
            }
        }
    }
}
