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

        public void CanBuild(int nbTurn) 
        { 
            for (int i=nbTurn; i >=0; i--)
            {
                // TO DO : Rajouter la fonction de construction au batiment (dans la classe batiment)
            }
        }
    }
}
