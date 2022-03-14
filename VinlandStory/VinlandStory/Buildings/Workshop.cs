using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class Workshop : Building
    {
        List<Lumberjack> _listlumberjacks;

        public Workshop(int x, int y, int length, int width, Resources cost, int radius, int nbWorkers) : base(x, y, length, width, new Resources(), radius, 1)
        {
            _listlumberjacks = new List<Lumberjack>();
        }
    }
}
