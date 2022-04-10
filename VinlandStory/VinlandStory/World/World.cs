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
        private Tile[,] _tiles;

        public Tile this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < Length && j >= 0 && j < Width)
                    return _tiles[i, j];
                else
                    return null;
            }
            private set
            {
                if (i >= 0 && i < Length && j >= 0 && j < Width)
                    _tiles[i, j] = value;
            }
        }
        public World(Random r)
        {
            Length = __LENGTH;
            Width = __WIDTH;
            _tiles = new Tile[Length, Width];
            GenerateWorld(r);
        }
        /// <summary>
        /// Print the whole world on screen
        /// </summary>
        public void PrintWorld()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _tiles[i, j].PrintTile();
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }
        /// <summary>
        /// Fill the world with randomly chosen tiles
        /// </summary>
        /// <param name="r">Random type variable</param>
        private void GenerateWorld(Random r)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int diceroll = r.Next(0, 4);
                    switch (diceroll)
                    {
                        case 0:
                            this[i, j] = new MeadowTile(r, i, j);
                            break;
                        case 1:
                            this[i, j] = new MeadowTile(r, i, j);
                            break;
                        case 2:
                            this[i, j] = new ForestTile(r, i, j);
                            break;
                        case 3:
                            this[i, j] = new DepositTile(r, i, j);
                            break;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    UpdateTile((Length / 2) - 5 + i, (Width / 2) - 12 + j, new MeadowTile(r, i, j));
                }
            }
        }
        /// <summary>
        /// Change a certain tile to another
        /// </summary>
        /// <param name="i">Row of tile</param>
        /// <param name="j">Column of tile</param>
        /// <param name="tile">Tile to replace to</param>
        /// <returns>True if ended well</returns>
        public bool UpdateTile(int i, int j, Tile tile)
        {
            if (i >= 0 && i < Length && j >= 0 && j < Width)
            {
                this[i, j] = tile;
                return true;
            }
            else
                return false;
        }
    }
}
