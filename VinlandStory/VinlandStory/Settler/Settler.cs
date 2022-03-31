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
        public Building Goal { get; set; }
        public Building Origin { get; private set; }
        protected bool _goingToGoal;

        public Settler(int x, int y, int velocity, double BirthRate, double DeathRate, Building goal, Building origin) 
        {
            _x = x;
            _y = y;
            _velocity = velocity;
            _birthRate = BirthRate;
            _deathRate = DeathRate;
            _hunger = false;
            _goingToGoal = true;
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

        public void Move()
        {
            if (_goingToGoal)
                MakeStep(Goal);
            else
                MakeStep(Origin);
        }
        private void MakeStep(Building Objective)
        {
            int MoveDist = (Objective.getX() - getX()) * (Objective.getX() - getX()) + (Objective.getY() - getY()) * (Objective.getY() - getY());
            int bestX = 0;
            int bestY = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; i <= 1; j++)
                {
                    int afterPotentialMoveDist = (Objective.getX() - getX() - i) * (Objective.getX() - getX() - i) + (Objective.getY() - getY() - j) * (Objective.getY() - getY() - j);
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
        public abstract bool Eat(bool hasEaten);
    }
}
