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
            //Prepare Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Vinland Story";

            //Pre-game function
            this.begin();

            //Intiate game
            _rand = new Random();
            _currentTurn = 0;
            _world = new World(_rand);
            _settlers = new List<Settler>();
            _buildings = new List<Building>();
            _resourcesOwned = new Resources(100, 100, 100);

            this.build(new Longhouse(_world.Length / 2 - 1, _world.Width / 2 - 1));
            this.build(new BuildersHouse(_world.Length / 2 - 2, _world.Width / 2 - 2));

            //Game itself
            while (_currentTurn < __MAX_TURNS)
            {
                this.playTurn();
            }

            this.endGame();
        }

        private void begin()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bienvenue dans VinlandStory !\n");
            Console.ResetColor();
            Console.WriteLine("Préparez-vous à revivre l'arrivée des Vikings sur de nouvelles terres vierges !");
            Console.WriteLine("Vous ne disposez que de 30 tours pour faire prospérer votre colonie. En tant que chef, prenez des décisions pour assurer la survie de tous !");
            Console.WriteLine("Êtes-vous prêt ?");
            Console.ReadLine();

            Console.Clear();
        }

        private void playTurn()
        {
            _currentTurn++;
            Console.Clear();
            Console.WriteLine("~~~~~ TOUR {0} ~~~~~\n", _currentTurn);
            _world.PrintWorld();
            Console.WriteLine();
            Console.Write(_resourcesOwned);
            Console.WriteLine("\tColons : {0}", _settlers.Count());
            Console.WriteLine();
            Console.WriteLine("Voici ce que vous pouvez faire : ");
            Console.WriteLine("- Tapez c - Construire un bâtiment.");
            Console.WriteLine("- Tapez i en sélectionnant une case - Révélez les ressources de la case");
            char k;
            do
            {
                k = Console.ReadKey().KeyChar;
            } while (k != 'c' && k != 'i');
            switch (k)
            {
                case 'c':
                    build
                    break;
                case 'i':
                    showInfos(Console.GetCursorPosition())
            }


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
