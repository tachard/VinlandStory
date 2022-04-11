using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Resources
    {
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Food { get; set; }

        public Resources(int wood, int stone, int food)
        {
            Wood = wood;
            Stone = stone;
            Food = food;
        }
        /// <summary>
        /// Return the amount of each resource in variable
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"Bois : {Wood}\tPierre : {Stone}\tNourriture : {Food}";
        }
    }
}
