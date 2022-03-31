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

            this.build(new Longhouse(_world.Length / 2 - 1, _world.Width / 2 - 1),new Builder(_world.Length / 2 - 1, _world.Width / 2 - 1));
            this.build(new BuildersHouse(_world.Length / 2 - 2, _world.Width / 2 - 2), new Builder(_world.Length / 2 - 2, _world.Width / 2 - 2));

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
            int totalBuilders = 0;
            List<Builder> unoccupiedBuilders = new List<Builder>();
            foreach(Settler settler in _settlers)
            {
                if (settler is Builder)
                {
                    Builder builder = settler as Builder;
                    totalBuilders++;
                    if (!builder.isOccupied())
                        unoccupiedBuilders.Add(builder);
                }
            }
            Console.WriteLine("Voici ce que vous pouvez faire : ");
            Console.WriteLine("- Tapez c - Construire un bâtiment. {0}/{1} bâtisseur.s disponibles",unoccupiedBuilders,totalBuilders);
            Console.WriteLine("- Tapez i en sélectionnant une case - Révélez les ressources de la case");
            Console.WriteLine("- Tapez une autre touche pour passer");
            char k;
            bool action;
            while (unoccupiedBuilders.Count>0)
            {
                do
                {
                    k = Console.ReadKey().KeyChar;
                } while (k != 'c' && k != 'i');
                switch (k)
                {
                    case 'c':
                        action = chooseBuildOption(unoccupiedBuilders[0]);
                        if (action)
                            unoccupiedBuilders.RemoveAt(0);
                        break;
                    case 'i':
                        showInfos(Console.CursorTop, Console.CursorLeft);
                        break;
                    default:
                        break;
                }
            }
            


            Console.ReadLine();
        }

        private void endGame() { }
        
        private bool chooseBuildOption(Builder b)
        {
            Console.WriteLine();
            Console.WriteLine("Choisissez un bâtiment à construire (tapez le numéro correspondant tout en sélectionnant la case où il sera mis) :");
            Console.WriteLine("0 - Retour");
            Console.WriteLine("1 - Cabane des bâtisseurs");
            Console.WriteLine("Coût :" + BuildersHouse.__BUILDERSHOUSE_COST.ToString());
            Console.WriteLine("2 - Cabane des chasseurs");
            Console.WriteLine("Coût :" + HuntersHut.__HUT_COST.ToString());
            Console.WriteLine("3 - Scierie");
            Console.WriteLine("Coût :" + Workshop.__WORKSHOP_COST.ToString());
            Console.WriteLine("4 - Mine");
            Console.WriteLine("Coût :" + Mine.__MINE_COST.ToString());
            char k;
            do
            {
                k = Console.ReadKey().KeyChar;
            } while (k != '0' && k != '1' && k != '2' && k != '3' && k != '4');
            switch (k)
            {
                case '0':
                    return false;
                case '1':
                    return build(new BuildersHouse(Console.CursorTop - 2, Console.CursorLeft),b);
                case '2':
                    return build(new HuntersHut(Console.CursorTop - 2, Console.CursorLeft), b);
                case '3':
                    return build(new Workshop(Console.CursorTop - 2, Console.CursorLeft), b);
                case '4':
                    return build(new Mine(Console.CursorTop - 2, Console.CursorLeft), b);
            }
            return false;
        }
        private bool build(Building build, Builder b)
        {
            if (_resourcesOwned.Wood < build.getCost().Wood || _resourcesOwned.Stone < build.getCost().Stone || _resourcesOwned.Food < build.getCost().Food)
            {
                Console.WriteLine("Pas assez de ressources");
                return false;
            }

            World tmp = _world;
            _buildings.Add(build);
            for (int i = 0; i <build.getWidth(); i++)
            {
                for (int j = 0; j < build.getLength(); j++)
                {
                    if(!tmp.UpdateTile(build.getX() + i, build.getY() + j, new BuildingTile(_rand, build)))
                    {
                        Console.WriteLine("Construction hors-limites !");
                        return false;
                    }
                        
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
                }
            }
        b.Goal = new BuildersHouse(Console.CursorTop - 2, Console.CursorLeft);
        return true;
        }
        private void showInfos(int x, int y)
        {
            Console.WriteLine("Position : (x,y)=({0},{1})", x, y);
            Console.WriteLine(_world.Tiles[x, y].Available);
            
            if(_world.Tiles[x,y] is BuildingTile)
            {
                BuildingTile tile = _world.Tiles[x, y] as BuildingTile;
                Console.WriteLine(tile.Build);
            }
        }
    }
}
