using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    public class Miner : Settler
    {
        public static readonly double __MINER_BIRTH_RATE = 0;
        public static readonly double __MINER_DEATH_RATE = 0;
        public static readonly int __MINER_MAX_STONE_WEARABLE = 400;
        public static readonly int __STONE_EARNED_EVERY_TURN = 60;

        private int _stone;
        private int _maxStone;

        public Miner(int x, int y, Building origin,World world) : base(x, y, __MINER_BIRTH_RATE, __MINER_DEATH_RATE, origin,world)
        {
            _stone = 0;
            _maxStone = __MINER_MAX_STONE_WEARABLE;
            SetNewGoal();

        }
        public int Stone { get => _stone; set => _stone = value; }

        /// <summary>
        /// Check if miner is full with resources
        /// </summary>
        /// <returns>true if full</returns>
        public bool IsFull()
        {
            return _stone == _maxStone;
        }
        /// <summary>
        /// Collect stone. If complete, takes nothing
        /// </summary>
        public void PickStone()
        {
            if (X == Goal.X && Y == Goal.Y)
            {
                if (__STONE_EARNED_EVERY_TURN > Goal.Available.Stone)
                {
                    int picked = Goal.Available.Stone;
                    Stone += picked;
                    Goal.Available.Stone -= picked;
                    SetNewGoal();
                }
                if (Stone + __STONE_EARNED_EVERY_TURN > _maxStone)
                {

                    int picked = _maxStone - Stone;
                    Goal.Available.Stone -= picked;
                    Stone = _maxStone;
                    Goal = null;
                    GoingToGoal = false;
                }
                else
                {
                    Stone += __STONE_EARNED_EVERY_TURN;
                }
            }
            else if (X == Origin.X || Y == Origin.Y)
            {
                Origin.Longhouse.ResourcesOwned.Stone += Stone;
                Stone = 0;
                SetNewGoal();
            }
        }

        public override void SetNewGoal()
        {
            for (int i = Origin.X - Origin.Radius; i < Origin.X + Origin.Radius + 1; i++)
            {
                for (int j = Origin.Y - Origin.Radius; j < Origin.Y + Origin.Radius + 1; j++)
                {
                    if (i>=0 && i<World.Length && j>=0 && j < World.Width)
                    {
                        if (World[i, j].Available.Stone > 0)
                        {
                            Goal = World[i, j];
                            GoingToGoal = true;
                        }
                    }
                    
                }
            }
        }
    }
}
