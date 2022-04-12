using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    public class Hunter : Settler
    {
        public static readonly double __HUNTER_BIRTH_RATE = 0;
        public static readonly double __HUNTER_DEATH_RATE = 0;
        public static readonly int __HUNTER_MAX_FOOD_WEARABLE = 400;
        public static readonly int __FOOD_EARNED_EVERY_TURN = 60;
        private int _food;
        private int _maxFood;

        public Hunter(int x, int y, Building origin, World world) : base(x, y, __HUNTER_BIRTH_RATE, __HUNTER_DEATH_RATE, origin, world)
        {
            _food = 0;
            _maxFood = __HUNTER_MAX_FOOD_WEARABLE;
            SetNewGoal();
        }
        public int Food { get => _food; set => _food = value; }
        /// <summary>
        /// Check if hunter is full
        /// </summary>
        /// <returns>True if full</returns>
        public bool IsFull()
        {
            return (_food == _maxFood);
        }
        /// <summary>
        /// Collect Food. If complete, collect nothing.
        /// </summary>
        public void CollectFood()
        {
            if (X == Goal.X && Y == Goal.Y)
            {
                if (__FOOD_EARNED_EVERY_TURN > Goal.Available.Food)
                {
                    int picked = Goal.Available.Food;
                    Food += picked;
                    Goal.Available.Food -= picked;
                    SetNewGoal();
                }
                if (Food + __FOOD_EARNED_EVERY_TURN > _maxFood)
                {

                    int picked = _maxFood - Food;
                    Goal.Available.Food -= picked;
                    Food = _maxFood;
                    Goal = null;
                    GoingToGoal = false;
                }
                else
                {
                    Food += __FOOD_EARNED_EVERY_TURN;
                }
            }
            else if (X == Origin.X || Y == Origin.Y)
            {
                Origin.Longhouse.ResourcesOwned.Food += Food;
                Food = 0;
                SetNewGoal();
            }
        }

        public override void SetNewGoal()
        {
            for(int i= Origin.X - Origin.Radius; i < Origin.X + Origin.Radius + 1; i++)
            {
                for(int j = Origin.Y - Origin.Radius;j < Origin.Y + Origin.Radius + 1;j++)
                {
                    if (World[i, j].Available.Food > 0)
                    {
                        Goal = World[i, j];
                    }  
                }
            }
        }
    }
}
