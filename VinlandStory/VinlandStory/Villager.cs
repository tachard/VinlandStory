using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Villager : Personnage
    {
        public Villager(int x, int y, int velocity, double BirthRate, double DeathRate) : base (x, y, velocity, BirthRate, DeathRate) { }
    }
}
