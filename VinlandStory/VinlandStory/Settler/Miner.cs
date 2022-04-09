using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Miner : Settler
    {
        public static readonly int __MINER_VELOCITY = 1;
        public static readonly double __MINER_BIRTH_RATE = 0;
        public static readonly double __MINER_DEATH_RATE = 0;
        public static readonly int __MINER_MAX_STONE_WEARABLE = 400;

        private int _stone;
        private int _maxStone;

        public Miner(int x, int y, Building origin) : base(x, y,__MINER_VELOCITY, __MINER_BIRTH_RATE, __MINER_DEATH_RATE, null, origin)
        {
            _stone = 0;
            _maxStone = __MINER_MAX_STONE_WEARABLE;

        }
        public int getStone()
        {
            return _stone;
        }
        public void setStone(int nvStone)
        {
            _stone = nvStone;
        }
        /// <summary>
        /// Check if miner is full with resources
        /// </summary>
        /// <returns>true if full</returns>
        public bool IsFull()
        {
            return (_stone == _maxStone);
        }
        /// <summary>
        /// Collect stone
        /// </summary>
        /// <param name="numberStone">Number of collected stone</param>
        /// <returns>true if collected</returns>
        public bool pickStone(int numberStone)
        {
            if (IsFull() == true)
            {
                return false;
            }
            else
            {
                //TO DO: revise this (in case of partial full)
                setStone(numberStone);
                return true;
            }
        }
    }
}
