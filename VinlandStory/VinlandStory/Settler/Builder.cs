using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Builder : Settler
    {
        public static readonly int __BUILDER_VELOCITY = 1;
        public static readonly double __BUILDER_BIRTH_RATE = 0;
        public static readonly double __BUILDER_DEATH_RATE = 0;

        public Builder(int x, int y) : base(x, y, __BUILDER_VELOCITY, __BUILDER_BIRTH_RATE, __BUILDER_DEATH_RATE)
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
