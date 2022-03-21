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
            _buildings.Add(new Longhouse(_world.Length / 2 - 1, _world.Width / 2 - 1));
            for(int i = 0; i < Longhouse.__LONGHOUSE_WIDTH; i++)
            {
                for(int j = 0; j < Longhouse.__LONGHOUSE_LENGTH; j++)
                {
                    _world.UpdateTile(_world.Length / 2 - 1 + i, _world.Width / 2 - 1 + j, new BuildingTile(_rand));
                }
            }
            for (int i = 0; i < Longhouse.__INITIAL_SETTLERS;i++)
            {
                _settlers.Add(new Villager(_world.Length / 2, _world.Width / 2 - 1));
            }
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
            //TO DO : complete
            Console.ReadLine();
        }
        
        private bool build(int x, int y, Building build)
        {
            World tmp = _world;
            _buildings.Add(build);
            for (int i = 0; i <build.Width; i++)
            {
                for (int j = 0; j < build.Length; j++)
                {
                    if(!tmp.UpdateTile(x + i, y + j, new BuildingTile(_rand)))
                        return false; 
                }
            }
            _world = tmp;
            for(int i = 0; i < build.Settler; i++)
            {
                switch (build.GetType())
                {
                    case BuildersHouse:
                        _settlers.Add(new Builder(x,y))
                }
            }
        }
    }
}
