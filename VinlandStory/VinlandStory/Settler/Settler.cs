using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    abstract class Settler
    {
        protected int _x;
        protected int _y;
        protected int _velocity;
        protected double _birthRate;
        protected double _deathRate;

        // TO DO : Rajouter les valeurs dans les sous-classes
        public Settler(int x, int y, int velocity, double BirthRate, double DeathRate) 
        {
            _x = x;
            _y = y;
            _velocity = velocity;
            _birthRate = BirthRate;
            _deathRate = DeathRate;
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
        public void Move(){ }
    }
}
