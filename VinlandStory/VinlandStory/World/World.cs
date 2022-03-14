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
        private Random _alea;

        public World()
        {
            Length = 16;
            Width = 16;
            _world = new Tile[Length, Width];
            this.generateWorld();
        }

        public override string ToString()
        {
            string output = "";
            for(int i = 0; i < Length; i++)
            {
                for(int j= 0; j < Width; j++)
                {
                    output += _world[i, j].ToString();
                }
                output += "\n";
            }
            return output;
        }

        private void generateWorld()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    switch (_alea.Next(0, 3))
                    {
                        case 0:
                            _world[i, j] = new MeadowTile(_alea);
                            break;
                        case 1:
                            _world[i, j] = new ForestTile(_alea);
                            break;
                        case 2:
                            _world[i, j] = new DepositTile(_alea);
                            break;
                    }
                }
            }
        }

        public int countSettler()
        {
            int count = 0;
            //TO DO: compter le nombre de villageois (penser au cas où y en a plusieurs sur une même case)
            return count;
        }

        public bool UpdateTile(int i, int j, Tile tile)
        {
            if (i >= 0 && i < Length && j >= 0 && j < Width)
            {
                _world[i, j] = tile;
                return true;
            }
            else
                return false;
        }
    }
}
