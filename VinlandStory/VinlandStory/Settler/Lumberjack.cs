using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Lumberjack : Settler
    {
        private int _wood;
        private int _maxWood;

        public Lumberjack(int x, int y, int velocity, double BirthRate, double DeathRate, int Wood, int maxWood) : base(x, y, velocity, BirthRate, DeathRate)
        {
            _wood = Wood;
            _maxWood = maxWood;
        }

        public int getWood()
        {
            return _wood;
        }
        public void setWood(int nvWood)
        {
            _wood = nvWood;
        }

        public bool IsFull()
        {
            return (_wood == _maxWood);
        }

        public bool cutWood(int numberWood)
        {
            // TO DO : Rajouter le nombre max de bûches (faire pareil pour les autres)
            if (IsFull() == true)  
            {
               return false;
            }
            else
            {
                setWood(numberWood);
                return true;
            }
        }
    }
}
