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
            _birthRate = nvBirth;
        }
        public double getDeath()
        {
            return _deathRate;
        }
        public void setDeath(double nvDeath)
        {
            _deathRate = nvDeath;
        }

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
        private void MakeStep(Tile goal)
        {
            int MoveDist = (goal.X - getX()) * (goal.X - getX()) + (goal.Y - getY()) * (goal.Y - getY());
            int bestX = 0;
            int bestY = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; i <= 1; j++)
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
            _x = bestX;
            _y = bestY;
        }
        public bool Live(Random r)
        {
            return r.NextDouble() > _deathRate;
        }
        public bool GiveBirth(Random r)
        {
            return r.NextDouble() < _birthRate;
        }
        public void Eat(bool hasEaten)
        {
            _hunger = false;
        }
    }
}
