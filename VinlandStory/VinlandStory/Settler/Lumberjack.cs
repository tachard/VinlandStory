using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Lumberjack(int x, int y) : base(x, y, __LUMBER_VELOCITY, __LUMBER_BIRTH_RATE, __LUMBER_DEATH_RATE)
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

        public bool IsFull()
        {
            return (_wood == _maxWood);
        }

        public bool cutWood(int numberWood)
        {
            if (IsFull())  
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
