﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Hunter : Settler
    {
        public static readonly int __HUNTER_VELOCITY = 1;
        public static readonly double __HUNTER_BIRTH_RATE = 0;
        public static readonly double __HUNTER_DEATH_RATE = 0;
        public static readonly int __HUNTER_MAX_FOOD_WEARABLE = 400;
        private int _food;
        private int _maxFood;
        
        public Hunter(int x, int y, Building origin) : base(x, y, __HUNTER_VELOCITY, __HUNTER_BIRTH_RATE, __HUNTER_DEATH_RATE, null, origin)
        {
            _food = 0;
            _maxFood = __HUNTER_MAX_FOOD_WEARABLE;
        }
        public int getFood()
        {
            return _food;
        }
        public void setFood(int nvFood)
        {
            _food = nvFood;
        }
        public bool IsFull()
        {
            return (_food == _maxFood);
        }

        public bool collectFood(int numberFood)
        {
            if (IsFull() == true)
            {
                return false;
            }
            else
            {
                setFood(numberFood);
                return true;
            }
        }
    }
}
