using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Miner : Personnage
    {
       private int _stone;
        private int _maxStone;

        public Miner(int x, int y, int velocity, double BirthRate, double DeathRate, int Stone, int maxStone) : base(x, y, velocity, BirthRate, DeathRate)
        {
            _stone = Stone;
            _maxStone = maxStone;
        }
        public int getStone()
        {
            return _stone;
        }
        public void setStone(int nvStone)
        {
            _stone = nvStone;
        }
        public bool IsFull()
        {
            return (_stone == _maxStone);
        }
        public bool pickStone(int numberStone)
        {
            if (IsFull() == true)
            {
                return false;
            }
            else
            {
                setStone(numberStone);
                return true;
            }
        }
    }
}
