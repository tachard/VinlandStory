using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Lumberjack : Personnage
    {
        private int _wood;

        public Lumberjack(int x, int y, int velocity, double BirthRate, double DeathRate, int Wood) : base(x, y, velocity, BirthRate, DeathRate)
        {
            _wood = Wood;
        }

        public int getWood()
        {
            return _wood;
        }
        public void setWood(int nvWood)
        {
            _wood = nvWood;
        }

        public void cutWood()
        {

        }
    }
}
