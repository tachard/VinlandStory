using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Builder : Personnage
    {
        public Builder(int x, int y, int velocity, double BirthRate, double DeathRate) : base(x, y, velocity, BirthRate, DeathRate)
        { }

        public void Build() { }
    }
}
