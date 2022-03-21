using System;
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

            //TO DO : Factoriser en une fonction
            this.build(_world.Length / 2 - 1, _world.Width / 2 - 1, new Longhouse(_world.Length / 2 - 1, _world.Width / 2 - 1));
            
            //Prepare Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Vinland Story";

            //Game itself
            while (_currentTurn < __MAX_TURNS)
            {
                this.playTurn();
            }
        }

        private void playTurn()
        {
            _currentTurn++;
            _world.PrintWorld();
            Console.WriteLine(_settlers[0]);
            Console.WriteLine(_buildings[0]);
            Console.ReadLine();
        }
        
        private int build(int x, int y, Building build)
        {
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
                    if(!tmp.UpdateTile(x + i, y + j, new BuildingTile(_rand)))
                        return -2; 
                }
            }
            _world = tmp;

            for(int i = 0; i < build.getWorkers(); i++)
            {
                switch (build.GetType().Name)
                {
                    case "BuildersHouse":
                        _settlers.Add(new Builder(x, y));
                        break;
                    case "Longhouse":
                        _settlers.Add(new Villager(x, y));
                        break;
                    case "HuntersHut":
                        _settlers.Add(new Hunter(x, y));
                        break;
                    case "Mine":
                        _settlers.Add(new Miner(x, y));
                        break;
                    case "Workshop":
                        _settlers.Add(new Lumberjack(x, y));
                        break;
                    default:
                        return -3;
                }
            }
            return 0;
        }
    }
}
