using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Hunter : Settler
    {
        private int _food;
        private int _maxFood;
        
        public Hunter(int x, int y, int velocity, double BirthRate, double DeathRate, int Food, int maxFood) : base(x, y, velocity, BirthRate, DeathRate)
        {
            _food = Food;
            _maxFood = maxFood;
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
