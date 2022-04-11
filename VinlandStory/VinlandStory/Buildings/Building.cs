using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    abstract class Building
    {
        protected int _x;
        protected int _y;
        protected int _length;
        protected int _width;
        private Resources _cost;
        protected int _radius;
        protected int _nbWorkers;
        protected Longhouse _longhouse;

        public Building(int x, int y, int length, int width, Resources cost, int radius, int nbWorkers, Longhouse longhouse)
        {
            _x = x;
            _y = y;
            _length = length;
            _width = width;
            _cost = cost;
            _radius = radius;
            _nbWorkers = nbWorkers;
            _longhouse = longhouse;
        }

        public int X => _x;

        public int Y => _y;

        public int Length => _length;

        public int Width => _width;

        public Resources Cost => _cost;

        public int Radius => _radius;

        public int Workers => _nbWorkers;

        public Longhouse Longhouse => _longhouse;
    }
}
