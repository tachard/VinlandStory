using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class World
    {
        public static readonly int __LENGTH = 30;
        public static readonly int __WIDTH = 30;
        public int Length { get; set; }
        public int Width { get; set; }
        public Tile[,] Tiles;

        public World(Random r)
        {
            Length = __LENGTH;
            Width = __WIDTH;
            Tiles = new Tile[Length, Width];
            this.generateWorld(r);
        }

        public void PrintWorld()
        {
            for (int i = 0; i < Length; i++)
            {
                for(int j= 0; j < Width; j++)
                {
                    Tiles[i, j].PrintTile();
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }

        private void generateWorld(Random r)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int diceroll = r.Next(0, 4);
                    switch (diceroll)
                    {
                        case 0:
                            Tiles[i, j] = new MeadowTile(r, i, j);
                            break;
                        case 1:
                            Tiles[i, j] = new MeadowTile(r, i, j);
                            break;
                        case 2:
                            Tiles[i, j] = new ForestTile(r, i, j);
                            break;
                        case 3:
                            Tiles[i, j] = new DepositTile(r, i, j);
                            break;
                    }
                }
            }
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 25; j++)
                {
                    UpdateTile(Length / 2 - 5 + i, Width / 2 - 12 + j, new MeadowTile(r, i, j));
                }
            }
        }

        public bool UpdateTile(int i, int j, Tile tile)
        {
            if (i >= 0 && i < Length && j >= 0 && j < Width)
            {
                Tiles[i, j] = tile;
                return true;
            }
            else
                return false;
        }
    }
}
