﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    class Game
    {
        public static readonly int __MAX_TURNS = 30;

        private int _currentTurn;
        private World _world;
        private List<Settler> _settlers;
        private List<Building> _buildings;
        private Resources _resourcesOwned;
        private Random _rand;

        public Game()
        {
            //Intiate game
            _rand = new Random();
            _currentTurn = 0;
            _world = new World(_rand);
            _settlers = new List<Settler>();
            _buildings = new List<Building>();
            _resourcesOwned = new Resources(100, 100, 100);

            this.build(_world.Length / 2 - 1, _world.Width / 2 - 1, new Longhouse(_world.Length / 2 - 1, _world.Width / 2 - 1));
            this.build(_world.Length / 2 - 2, _world.Length / 2 - 2, new BuildersHouse(_world.Length / 2 - 2, _world.Length / 2 - 2));

            //Prepare Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Vinland Story";

            //Game itself
            while (_currentTurn < __MAX_TURNS)
            {
                this.playTurn();
            }

            this.endGame();
        }

        private void playTurn()
        {
            _currentTurn++;
            _world.PrintWorld();
            //TO DO:Complete
            Console.ReadLine();
        }

        public void endGame() { }
        
        private int build(Building build)
        {
            //TO DO: Modify to not include x,y
            /*Output codes :
             * 0 : No problems
             * -1 : Not enough resources
             * -2 : Building out of range
             * -3 : Cannot add new villagers
             */

            if (_resourcesOwned.Wood < build.getCost().Wood || _resourcesOwned.Stone < build.getCost().Stone || _resourcesOwned.Food < build.getCost().Food)
                return -1;

            World tmp = _world;
            _buildings.Add(build);
            for (int i = 0; i <build.getWidth(); i++)
            {
                for (int j = 0; j < build.getLength(); j++)
                {
                    if(!tmp.UpdateTile(build.getX() + i, build.getY() + j, new BuildingTile(_rand)))
                        return -2; 
                }
            }
            _world = tmp;

            for(int i = 0; i < build.getWorkers(); i++)
            {
                switch (build.GetType().Name)
                {
                    case "BuildersHouse":
                        _settlers.Add(new Builder(build.getX(), build.getY()));
                        break;
                    case "Longhouse":
                        _settlers.Add(new Villager(build.getX(), build.getY()));
                        break;
                    case "HuntersHut":
                        _settlers.Add(new Hunter(build.getX(), build.getY()));
                        break;
                    case "Mine":
                        _settlers.Add(new Miner(build.getX(), build.getY()));
                        break;
                    case "Workshop":
                        _settlers.Add(new Lumberjack(build.getX(), build.getY()));
                        break;
                    default:
                        return -3;
                }
            }
            return 0;
        }
    }
}
