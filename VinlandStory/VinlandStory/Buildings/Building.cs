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
        Resources _cost;
        protected int _radius;
        protected int _nbWorkers;

        public Building(int x, int y, int length, int width, Resources cost, int radius, int nbWorkers)
        {
            _x = x;
            _y = y;
            _length = length;
            _width = width;
            _cost = cost;
            _radius = radius;
            _nbWorkers = nbWorkers;
        }

        public int getX()
        {
            return _x;
        }
     
        public int getY()
        {
            return _y;
        }

        public int getLength()
        {
            return _length;
        }

        public int getWidth()
        {
            return _width;
        }

        public Resources getCost()
        {
            return _cost;
        }

        public int getRadius()
        {
            return _radius;
        }

        public int getWorkers()
        {
            return _nbWorkers;
        }
    }
}
