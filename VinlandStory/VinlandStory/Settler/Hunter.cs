using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Hunter : Personnage
    {
        private int _food;
        
        public Hunter(int x, int y, int velocity, double BirthRate, double DeathRate, int Food) : base(x, y, velocity, BirthRate, DeathRate)
        {
            _food = Food;
        }
        public int getFood()
        {
            return _food;
        }
        public void setFood(int nvFood)
        {
            _food = nvFood;
        }

        public void cutFood()
        {

        }
    }
}
