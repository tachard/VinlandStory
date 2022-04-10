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

        /// <summary>
        /// Create a game and play it
        /// </summary>
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
            _resourcesOwned = new Resources(120, 105, 100);

            Longhouse mainBuilding = new Longhouse(_world.Length / 2 - 1, _world.Width / 2 - 1);
            this.Build(mainBuilding, new Builder(_world.Length / 2 - 1, _world.Width / 2 - 1, mainBuilding));
            BuildersHouse buildHouse = new BuildersHouse(_world.Length / 2 - 2, _world.Width / 2 - 2);
            this.Build(buildHouse, new Builder(_world.Length / 2 - 2, _world.Width / 2 - 2, buildHouse));

            //Game itself
            while (_currentTurn < __MAX_TURNS && _settlers.Count>0)
            {
                this.playTurn();
            }

            this.endGame();
        }
        /// <summary>
        /// Show pre-game text
        /// </summary>
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
        /// <summary>
        /// Play a complete turn : user choice + settlers' automation
        /// </summary>
        private void playTurn()
        {
            //Beginning of turn
            _currentTurn++;
            Console.Clear();
            Console.WriteLine("~~~~~ TOUR {0} ~~~~~\n", _currentTurn);
            _world.PrintWorld();
            Console.WriteLine();
            Console.Write(_resourcesOwned);
            Console.WriteLine("\tColons : {0}", _settlers.Count());
            Console.WriteLine();
            //User interaction
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
            
            char k;
            bool action;
            Console.WriteLine("Voici ce que vous pouvez faire : ");
            Console.WriteLine("- Tapez c - Construire un bâtiment. {0}/{1} bâtisseur.s disponibles", unoccupiedBuilders.Count(), totalBuilders);
            Console.WriteLine("- Tapez i - Révélez les ressources de la case");
            Console.WriteLine("- Tapez une autre touche pour passer");

            k = Console.ReadKey().KeyChar;
            switch (k)
            {
                case 'c':
                    action = ChooseBuildOption(unoccupiedBuilders[0]);
                    if (action)
                        unoccupiedBuilders.RemoveAt(0);
                    break;
                case 'i':
                    Console.Write("Entrez la ligne de la case :");
                    int ligne = int.Parse(Console.ReadLine());
                    Console.Write("Entrez la ligne de la case :");
                    int colonne = int.Parse(Console.ReadLine());
                    showInfos(ligne,colonne);
                    break;
                default:
                    break;
            }

            //Automatic behaviour
            CheckHunger();
            CheckLife();
            Move();
        }
        /// <summary>
        /// Show the end of game and ask for a new one
        /// </summary>
        private void endGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FIN DE PARTIE");
            Console.ResetColor();
            if (_settlers.Count == 0)
            {
                Console.WriteLine("Malheureusement, votre tribu Viking n'a pas survécu aux dures conditions de leur environnment ...");
            }
            else
            {
                Console.WriteLine("Vous avez réussi là où tous ont échoué. Vous serez célébrés pour les siècles à venir comme le grand conquérant Viking !");
            }
            Console.WriteLine();
            Console.WriteLine("Vos ressouces en fin de partie :");
            Console.WriteLine(_resourcesOwned.ToString() + "\tColons : " + _settlers.Count);

            Console.WriteLine();
            Console.WriteLine("Voulez-vous refaire une partie (o/n)");
            char k;
            do
            {
                k = Console.ReadKey().KeyChar;
            } while (k != 'y' && k != 'n');
            switch (k)
            {
                case 'y':
                    Game g2 = new Game();
                    break;
                case 'n':
                    break;
            }
        }
        /// <summary>
        /// Ask the player what to build
        /// </summary>
        /// <param name="b">Builder that will build</param>
        /// <returns>Boolean if build is possible</returns>
        private bool ChooseBuildOption(Builder b)
        {
            Console.WriteLine();
            Console.WriteLine("Choisissez un bâtiment à construire (tapez le numéro) :");
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

            int ligne=0;
            int colonne=0;
            if (k != '0')
            {
                Console.WriteLine();
                do
                {
                    Console.Write("Choisissez la ligne : ");
                    ligne = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Choisissez la colonne : ");
                    colonne = int.Parse(Console.ReadLine()) - 1;
                } while (ligne <= 0 || ligne > _world.Length || colonne <= 0 || colonne > _world.Width);
            }

            switch (k)
            {
                case '0':
                    return false;
                case '1':
                    return Build(new BuildersHouse(ligne+1, colonne+1),b);
                case '2':
                    return Build(new HuntersHut(ligne+1, colonne+1), b);
                case '3':
                    return Build(new Workshop(ligne+1, colonne+1), b);
                case '4':
                    return Build(new Mine(ligne+1, colonne+1), b);
                default:
                    return false;
            }
        }
        /// <summary>
        /// Look if building is possible and build if possible
        /// </summary>
        /// <param name="build">Building to be built</param>
        /// <param name="b">Builder that will build</param>
        /// <returns>Boolean if build is possible</returns>
        private bool Build(Building build, Builder b)
        {
            if (_resourcesOwned.Wood < build.getCost().Wood || _resourcesOwned.Stone < build.getCost().Stone || _resourcesOwned.Food < build.getCost().Food)
            {
                Console.WriteLine("Pas assez de ressources");
                return false;
            }

            World tmp = _world;
            
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
                        _settlers.Add(new Builder(build.getX(), build.getY(), build));
                        break;
                    case "Longhouse":
                        _settlers.Add(new Villager(build.getX(), build.getY(), build));
                        break;
                    case "HuntersHut":
                        _settlers.Add(new Hunter(build.getX(), build.getY(), build));
                        break;
                    case "Mine":
                        _settlers.Add(new Miner(build.getX(), build.getY(), build));
                        break;
                    case "Workshop":
                        _settlers.Add(new Lumberjack(build.getX(), build.getY(), build));
                        break;
                }
            }
            _buildings.Add(build);
            _resourcesOwned.Wood -= build.getCost().Wood ;
            _resourcesOwned.Stone -= build.getCost().Stone;
            _resourcesOwned.Food -= build.getCost().Food;
            b.Goal = build;
        return true;
        }
        /// <summary>
        /// Show further informations about a certain tile
        /// </summary>
        /// <param name="x">Row of tile (start to 1)</param>
        /// <param name="y">Column of tile (start to 1)</param>
        private void showInfos(int x, int y)
        {
            Console.WriteLine("Position : (x,y)=({0},{1})", x, y);
            Console.WriteLine(_world[x-1, y-1].Available);
            
            if(_world[x-1,y-1] is BuildingTile)
            {
                BuildingTile tile = _world[x-1, y-1] as BuildingTile;
                Console.WriteLine(tile.Build);
            }
        }
        /// <summary>
        /// Make every settler eat if possible
        /// </summary>
        private void CheckHunger()
        {
            foreach(Settler s in _settlers)
            {
                if (s is Villager)
                {
                    Villager v = (Villager)s;
                    if (_resourcesOwned.Food > 0)
                    {
                        v.Eat(true);
                        _resourcesOwned.Food -= 1;
                    }
                    else
                        v.Eat(false);
                }
            }
        }
        /// <summary>
        /// Move every settler
        /// </summary>
        private void Move()
        {
            foreach (Settler s in _settlers)
            {
                s.Move(_rand);
            }
        }
        /// <summary>
        /// Check if settlers are not dead and they give birth
        /// </summary>
        private void CheckLife()
        {
            Settler[] tmp = new Settler[_settlers.Count];
            _settlers.CopyTo(tmp);
            //Check if still alive
            for(int i=0;i<_settlers.Count;i++)
            {
                if (!_settlers[i].Live(_rand))
                    tmp[i]=null;
            }
            _settlers = new List<Settler>(tmp);
            _settlers.RemoveAll(x => x == null);

            List<Settler> tmp2 = new List<Settler>(_settlers);
            //Check if gives birth
            foreach(Settler s in _settlers)
            {
                if (s.GiveBirth(_rand))
                    tmp2.Add(new Villager(s.getX(), s.getY(), _buildings[0]));
            }
            _settlers = new List<Settler>(tmp2);
            _settlers.RemoveAll(x => x == null);
        }
    }
}
