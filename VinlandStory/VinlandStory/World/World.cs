using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class World
    {
        public static readonly int __LENGTH = 16;
        public static readonly int __WIDTH = 16;
        public int Length { get; set; }
        public int Width { get; set; }
        private Tile[,] _world;

        public World(Random r)
        {
            Length = __LENGTH;
            Width = __WIDTH;
            _world = new Tile[Length, Width];
            this.generateWorld(r);
        }

        public void PrintWorld()
        {
            for (int i = 0; i < Length; i++)
            {
                for(int j= 0; j < Width; j++)
                {
                    _world[i, j].PrintTile();
                }
                Console.Write("\n");
            }
        }

        private void generateWorld(Random r)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int diceroll = r.Next(0, 10);
                    switch (diceroll)
                    {
                        case 0:
                            _world[i, j] = new MeadowTile(r);
                            break;
                        case 1:
                            _world[i, j] = new MeadowTile(r);
                            break;
                        case 2:
                            _world[i, j] = new MeadowTile(r);
                            break;
                        case 3:
                            _world[i, j] = new MeadowTile(r);
                            break;
                        case 4:
                            _world[i, j] = new ForestTile(r);
                            break;
                        case 5:
                            _world[i, j] = new ForestTile(r);
                            break;
                        case 6:
                            _world[i, j] = new ForestTile(r);
                            break;
                        case 7:
                            _world[i, j] = new DepositTile(r);
                            break;
                        case 8:
                            _world[i, j] = new DepositTile(r);
                            break;
                        case 9:
                            _world[i, j] = new DepositTile(r);
                            break;
                    }
                }
            }
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
