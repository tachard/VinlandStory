using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class Mine : Building
    {
        List<Miner> _listminers;

        public Mine(int x, int y, int length, int width, Resources cost, int radius, int nbWorkers) : base(x, y, length, width, new Resources(), radius, 1)
        {
            _listminers = new List<Miner>();
        }
    }
}
