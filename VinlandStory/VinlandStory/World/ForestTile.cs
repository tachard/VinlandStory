﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class ForestTile:Tile
    {
        private static readonly Resources __FOREST_RESOURCES_MIN = new Resources(150, 0, 40);
        private static readonly Resources __FOREST_RESOURCES_MAX = new Resources(150, 0, 40);

        public ForestTile(Random alea) : base(__FOREST_RESOURCES_MIN, __FOREST_RESOURCES_MAX, alea) { }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            return "♣";
        }
    }
}