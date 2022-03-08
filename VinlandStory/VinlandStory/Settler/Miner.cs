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

        public Miner(int x, int y, int velocity, double BirthRate, double DeathRate, int Stone) : base(x, y, velocity, BirthRate, DeathRate)
        {
            _stone = Stone;
        }
        public int getStone()
        {
            return _stone;
        }
        public void setStone(int nvStone)
        {
            _stone = nvStone;
        }
        public void pickStone()
        { }
    }
}
