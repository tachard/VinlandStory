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
        protected int _velocity;
        protected double _birthRate;
        protected double _deathRate;
        protected bool _hunger;
        public Tile Goal { get; set; }
        public Building Origin { get; protected set; }
        protected bool _goingToGoal;

        public Settler(int x, int y, int velocity, double BirthRate, double DeathRate, Tile goal, Building origin) 
        {
            _x = x;
            _y = y;
            _velocity = velocity;
            _birthRate = BirthRate;
            _deathRate = DeathRate;
            _hunger = false;
            _goingToGoal = false;
            Goal = goal;
            Origin = origin;
        }

        public int getX()
        {
            return _x;
        }
        public void setX(int nvX)
        {
            _x = nvX;
        }
        public int getY()
        {
            return _y;
        }
        public void setY(int nvY)
        {
            _y = nvY;
        }
        public int getVelocity()
        {
            return _velocity;
        }
        public void setVelocity(int nvVelocity)
        {
            _velocity = nvVelocity;
        }
        public double getBirth()
        {
            return _birthRate;
        }
        public void setBirth(double nvBirth)
        {
            if (nvBirth < 0)
                _birthRate = 0;
            else if (nvBirth > 1)
                _birthRate = 1;
            else
                _birthRate = nvBirth;
        }
        public double getDeath()
        {
            return _deathRate;
        }
        public void setDeath(double nvDeath)
        {
            if (nvDeath < 0)
                _deathRate = 0;
            else if (nvDeath > 1)
                _deathRate = 1;
            _deathRate = nvDeath;
        }

        /// <summary>
        /// Make a move towards a goal.
        /// </summary>
        /// <param name="r">Random type variable</param>
        public void Move(Random r)
        {
            if (_goingToGoal)
                MakeStep(Goal);
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
            int MoveDist = (goal.X - getX()) * (goal.X - getX()) + (goal.Y - getY()) * (goal.Y - getY());
            int bestX = getX();
            int bestY = getY();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int afterPotentialMoveDist = (goal.X - getX() - i) * (goal.X - getX() - i) + (goal.Y - getY() - j) * (goal.Y - getY() - j);
                    if (afterPotentialMoveDist < MoveDist)
                    {
                        MoveDist = afterPotentialMoveDist;
                        bestX = _x + i;
                        bestY = _y + j;
                    }
                }
            }
            setX(bestX);
            setY(bestY);
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
    }
}
