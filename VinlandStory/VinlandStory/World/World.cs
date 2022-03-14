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
        private Random _alea = new Random();

        public World()
        {
            Length = 16;
            Width = 16;
            _world = new Tile[Length, Width];
            this.generateWorld();
        }

        public void PrintWorld()
        {
            for(int i = 0; i < Length; i++)
            {
                for(int j= 0; j < Width; j++)
                {
                    _world[i, j].PrintTile();
                }
                Console.Write("\n");
            }

            //TO DO : Ajouter Longhouse + Builder's house + MeadowTile around it
        }

        private void generateWorld()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int diceroll = _alea.Next(0, 3);
                    switch (diceroll)
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
