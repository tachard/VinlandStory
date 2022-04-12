﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    public class Builder : Settler
    {
        public static readonly double __BUILDER_BIRTH_RATE = 0;
        public static readonly double __BUILDER_DEATH_RATE = 0;

        public Builder(int x, int y, Building origin, World world) : base(x, y, __BUILDER_BIRTH_RATE, __BUILDER_DEATH_RATE, origin, world) { }

        /// <summary>
        /// Check if occupied
        /// </summary>
        /// <returns></returns>
        public bool IsOccupied()
        {
            return Goal != null;
        }

        /// <summary>
        /// If builder is on good place, sets goal to null and go back to home
        /// </summary>
        public void Build()
        {
            if (Goal != null)
            {
                if (X == Goal.X && Y == Goal.Y)
                {
                    Goal = null;
                    GoingToGoal = false;
                }
            }
            
        }
        public override void SetNewGoal() { }
    }
}
