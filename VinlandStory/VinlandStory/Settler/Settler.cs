using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    abstract class Settler
    {
        protected int _x;
        protected int _y;
        protected double _birthRate;
        protected double _deathRate;
        protected bool _hunger;
        public Tile Goal { get; set; }
        public Building Origin { get; protected set; }
        public bool GoingToGoal { get; set; }
        public World World { get; private set; }

        public Settler(int x, int y, double BirthRate, double DeathRate, Building origin, World world)
        {
            _x = x;
            _y = y;
            _birthRate = BirthRate;
            _deathRate = DeathRate;
            _hunger = false;
            GoingToGoal = true;
            Goal = null;
            Origin = origin;
            World = world;
        }

        public int X { get => _x; set => _x = value; }

        public int Y { get => _y; set => _y = value; }

        public double Birth
        {
            get => _birthRate;
            set
            {
                if (value < 0)
                    _birthRate = 0;
                else if (value > 1)
                    _birthRate = 1;
                else
                    _birthRate = value;
            }
        }

        public double Death
        {
            get => _deathRate;
            set
            {
                if (value < 0)
                    _deathRate = 0;
                else if (value > 1)
                    _deathRate = 1;
                _deathRate = value;
            }
        }

        /// <summary>
        /// Make a move towards a goal.
        /// </summary>
        /// <param name="r">Random type variable</param>
        public void Move(Random r)
        {
            if (GoingToGoal)
            {
                MakeStep(Goal);
            }
            else
            {
                Tile origin = new BuildingTile(r, Origin);
                MakeStep(origin);
            }

        }
        /// <summary>
        /// Choose the best way to go to goal.
        /// </summary>
        /// <param name="goal">Goal Tile</param>
        private void MakeStep(Tile goal)
        {
            if (goal != null)
            {
                int MoveDist = ((goal.X - X) * (goal.X - X)) + ((goal.Y - Y) * (goal.Y - Y));
                int bestX = X;
                int bestY = Y;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int afterPotentialMoveDist = ((goal.X - X - i) * (goal.X - X - i)) + ((goal.Y - Y - j) * (goal.Y - Y - j));
                        if (afterPotentialMoveDist < MoveDist)
                        {
                            MoveDist = afterPotentialMoveDist;
                            bestX = X + i;
                            bestY = Y + j;
                        }
                    }
                }
                X = bestX;
                Y = bestY;
            }
            
        }
        /// <summary>
        /// Choose randomly (knowing probability to die) if settler dies.
        /// </summary>
        /// <param name="r">Random type variable</param>
        /// <returns>False if dies</returns>
        public bool Live(Random r)
        {
            return r.NextDouble() > _deathRate;
        }
        /// <summary>
        /// Choose randomly (knowing probability of giving birth) if settler gives birth.
        /// </summary>
        /// <param name="r">Random type variable</param>
        /// <returns>true if gives birth</returns>
        public bool GiveBirth(Random r)
        {
            return r.NextDouble() < _birthRate;
        }
        /// <summary>
        /// Gives new goal to settler.
        /// </summary>
        abstract public void SetNewGoal();
    }
}
