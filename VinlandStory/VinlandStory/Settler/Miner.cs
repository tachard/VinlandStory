using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Miner(int x, int y) : base(x, y,__MINER_VELOCITY, __MINER_BIRTH_RATE, __MINER_DEATH_RATE)
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
        public bool IsFull()
        {
            return (_stone == _maxStone);
        }
        public bool pickStone(int numberStone)
        {
            if (IsFull() == true)
            {
                return false;
            }
            else
            {
                setStone(numberStone);
                return true;
            }
        }
    }
}
