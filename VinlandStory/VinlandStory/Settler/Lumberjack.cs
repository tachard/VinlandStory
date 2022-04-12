using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    public class Lumberjack : Settler
    {
        public static readonly double __LUMBER_BIRTH_RATE = 0;
        public static readonly double __LUMBER_DEATH_RATE = 0;
        public static readonly int __LUMBER_MAX_WOOD_WEARABLE = 400;
        public static readonly int __WOOD_EARNED_EVERY_TURN = 60;

        private int _wood;
        private int _maxWood;

        public Lumberjack(int x, int y, Building origin, World world) : base(x, y, __LUMBER_BIRTH_RATE, __LUMBER_DEATH_RATE, origin, world)
        {
            _wood = 0;
            _maxWood = __LUMBER_MAX_WOOD_WEARABLE;
            SetNewGoal();
        }

        public int Wood { get => _wood; set => _wood = value; }

        /// <summary>
        /// Check if lumberjack is full of wood
        /// </summary>
        /// <returns>true if full</returns>
        public bool IsFull()
        {
            return _wood == _maxWood;
        }
        /// <summary>
        /// Collect a certain amount of wood
        /// </summary>
        public void CutWood()
        {
            if (X == Goal.X && Y == Goal.Y)
            {
                if (__WOOD_EARNED_EVERY_TURN > Goal.Available.Wood)
                {
                    int picked = Goal.Available.Wood;
                    Wood += picked;
                    Goal.Available.Wood -= picked;
                    SetNewGoal();
                }
                if (Wood + __WOOD_EARNED_EVERY_TURN > _maxWood)
                {

                    int picked = _maxWood - Wood;
                    Goal.Available.Wood -= picked;
                    Wood = _maxWood;
                    Goal = null;
                    GoingToGoal = false;
                }
                else
                {
                    Wood += __WOOD_EARNED_EVERY_TURN;
                }
            }
            else if (X == Origin.X || Y == Origin.Y)
            {
                Origin.Longhouse.ResourcesOwned.Wood += Wood;
                Wood = 0;
                SetNewGoal();
            }
        }

        public override void SetNewGoal()
        {
            for (int i = Origin.X - Origin.Radius; i < Origin.X + Origin.Radius + 1; i++)
            {
                for (int j = Origin.Y - Origin.Radius; j < Origin.Y + Origin.Radius + 1; j++)
                {
                    if (World[i, j].Available.Wood > 0)
                    {
                        Goal = World[i, j];
                    }
                }
            }
        }
    }
}
