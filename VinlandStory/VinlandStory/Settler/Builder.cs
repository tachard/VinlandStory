﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Builder : Settler
    {
        public static readonly int __BUILDER_VELOCITY = 1;
        public static readonly double __BUILDER_BIRTH_RATE = 0;
        public static readonly double __BUILDER_DEATH_RATE = 0;
        public Building Goal { get; set; }

        public Builder(int x, int y) : base(x, y, __BUILDER_VELOCITY, __BUILDER_BIRTH_RATE, __BUILDER_DEATH_RATE){
            Goal = null;
        }

        public bool isOccupied()
        {
            return Goal != null;
        }
    }
}
