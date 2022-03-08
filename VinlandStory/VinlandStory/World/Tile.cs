using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    abstract class Tile
    {
        public Resources Available { get; set; }
        public Resources AvailableMin { get; private set; }
        public Resources AvailableMax { get; private set; }

        public abstract void Update(Tile t);

        public bool IsSettlerOn()
        {
            //TO DO: A implémenter
        } 
    }
}
