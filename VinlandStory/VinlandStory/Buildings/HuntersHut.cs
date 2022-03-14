using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class HuntersHut : Building
    {
        List<Hunter> _listhunters;

        public HuntersHut(int x, int y, int length, int width, Resources cost, int radius, int nbWorkers) : base(x,y,length,width,new Resources(), radius, 1)
        {
            _listhunters = new List<Hunter>();
        }
    }
}
