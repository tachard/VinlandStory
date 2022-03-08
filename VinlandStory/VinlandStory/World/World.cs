using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class World
    {
        public int Length { get; set; }
        public int Width { get; set; }
        private Tile[,] _world;
        private Resources _totalAvailableMin;
        private Resources _totalAvailableMax;
        private Random _alea;

        public World()
        {
            Length = 16;
            Width = 16;
            _world = new Tile[Length, Width];
            _totalAvailableMin = new Resources(4000, 4000, 4000);
            _totalAvailableMin = new Resources(7000, 7000, 7000);
            this.generateWorld(_alea);
        }

        public override string ToString()
        {
            //TO DO: Implémenter ToString()
            return base.ToString();
        }

        private void generateWorld(Random r)
        {
            //TO DO: Implémente la fonction pour qu'elle remplisse de manière cohérente le monde
        }

        public int countSettler()
        {
            int count = 0;
            //TO DO: compter le nombre de villageois (penser au cas où y en a plusieurs sur une même case)
            return count;
        }
    }
}
