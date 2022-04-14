using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory
{
    public class Game
    {
        public static readonly int __MAX_TURNS = 30;

        private int _currentTurn;
        private World _world;
        private List<Settler> _settlers;
        private List<Building> _buildings;
        private Longhouse _longhouse;


        /// <summary>
        /// Create a game and play it
        /// </summary>
        public Game()
        {
            //Prepare Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Vinland Story";

            //Pre-game function
            Begin();

            //Intiate game
            _currentTurn = 0;
            _world = new World();
            _settlers = new List<Settler>();
            _buildings = new List<Building>();

            _longhouse = new Longhouse((_world.Length / 2) - 1, (_world.Width / 2) - 1, new Resources(120, 105, 100));
            Build(_longhouse, new Builder((_world.Length / 2) - 1, (_world.Width / 2) - 1, null, _world));
            BuildersHouse buildHouse = new BuildersHouse((_world.Length / 2) - 2, (_world.Width / 2) - 2,_longhouse);
            Build(buildHouse, new Builder((_world.Length / 2) - 2, (_world.Width / 2) - 2, null, _world));

            //Game itself
            while (_currentTurn < __MAX_TURNS && CountVillagers > 0)
            {
                PlayTurn();
            }

            EndGame();
        }
        private int CountVillagers
        {
            get
            {
                List<Settler> tmp = new List<Settler>(_settlers);
                tmp.RemoveAll(x => x is Builder);
                tmp.RemoveAll(x => x is Hunter);
                tmp.RemoveAll(x => x is Lumberjack);
                tmp.RemoveAll(x => x is Miner);

                return tmp.Count;
            }
        }

        /// <summary>
        /// Show pre-game text
        /// </summary>
        private void Begin()
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
        private void PlayTurn()
        {
            //Beginning of turn
            _currentTurn++;
            Console.Clear();
            Console.WriteLine("~~~~~ TOUR {0} ~~~~~\n", _currentTurn);
            _world.PrintWorld();
            Console.WriteLine();
            Console.Write(_longhouse.ResourcesOwned);
            Console.WriteLine("\tColons : {0}", CountVillagers); 
            //The two first builders are removed from the list _settlers
            Console.WriteLine();
            //User interaction
            int totalBuilders = 0;
            List<Builder> unoccupiedBuilders = new List<Builder>();
            foreach (Settler settler in _settlers)
            {
                if (settler is Builder)
                {
                    Builder builder = settler as Builder;
                    totalBuilders++;
                    if (!builder.IsOccupied())
                    {
                        unoccupiedBuilders.Add(builder);
                    }
                }
            }

            char k;
            bool action;
            do
            {
                Console.WriteLine("Voici ce que vous pouvez faire : ");
                Console.WriteLine("- Tapez c - Construire un bâtiment. {0}/{1} bâtisseur.s disponibles", unoccupiedBuilders.Count(), totalBuilders);
                Console.WriteLine("- Tapez i - Révélez les ressources de la case");
                Console.WriteLine("- Tapez p - Mettre fin au tour");
                k = Console.ReadKey().KeyChar;
                switch (k)
                {
                    case 'c':
                        Console.WriteLine();
                        action = ChooseBuildOption(unoccupiedBuilders[0]);
                        if (action)
                            unoccupiedBuilders.RemoveAt(0);
                        break;
                    case 'i':
                        Console.WriteLine();
                        Console.Write("Entrez la ligne de la case : ");
                        int ligne;
                        while (!int.TryParse(Console.ReadLine(), out ligne) && ligne <= 0 || ligne > _world.Length) ;

                        Console.Write("Entrez la colonne de la case :");
                        int colonne;
                        while (int.TryParse(Console.ReadLine(), out colonne) && colonne <= 0 || colonne > _world.Width) ;

                        ShowInfos(ligne-1, colonne-1);
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            } while (k != 'c' && k!='p');
            

            //Automatic behaviour
            CheckHunger();
            CheckLife();
            Move();
            PickResources();
        }
        /// <summary>
        /// Show the end of game and ask for a new one
        /// </summary>
        private void EndGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FIN DE PARTIE");
            Console.ResetColor();
            if (CountVillagers == 0)
            {
                Console.WriteLine("Malheureusement, votre tribu Viking n'a pas survécu aux dures conditions de leur environnement ...");
            }
            else
            {
                Console.WriteLine("Vous avez réussi là où tous ont échoué. Les sagas vous célébreront pour les siècles à venir comme le grand conquérant Viking !");
            }
            Console.WriteLine();
            Console.WriteLine("Vos ressouces en fin de partie :");
            Console.WriteLine(_longhouse.ResourcesOwned.ToString() + "\tColons : " + _settlers.Count);

            Console.WriteLine();
            Console.WriteLine("Voulez-vous refaire une partie (o/n)");
            char k;
            do
            {
                k = Console.ReadKey().KeyChar;
            } while (k != 'o' && k != 'n');
            switch (k)
            {
                case 'o':
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

            int ligne = 0;
            int colonne = 0;
            if (k != '0')
            {
                Console.WriteLine();
                Console.Write("Choisissez la ligne : ");
                while (!int.TryParse(Console.ReadLine(), out ligne) && ligne <= 0 || ligne > _world.Length) ;
                Console.Write("Choisissez la colonne : ");
                while (!int.TryParse(Console.ReadLine(), out colonne) && colonne <= 0 || colonne > _world.Width) ;
            }

            switch (k)
            {
                case '0':
                    return false;
                case '1':
                    return Build(new BuildersHouse(ligne - 1, colonne - 1, _longhouse), b);
                case '2':
                    return Build(new HuntersHut(ligne - 1, colonne - 1, _longhouse), b);
                case '3':
                    return Build(new Workshop(ligne - 1, colonne - 1, _longhouse), b);
                case '4':
                    return Build(new Mine(ligne - 1, colonne - 1, _longhouse), b);
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
            if (_longhouse.ResourcesOwned.Wood < build.Cost.Wood || _longhouse.ResourcesOwned.Stone < build.Cost.Stone || _longhouse.ResourcesOwned.Food < build.Cost.Food)
            {
                Console.WriteLine("Pas assez de ressources");
                return false;
            }

            World tmp = _world;

            for (int i = 0; i < build.Width; i++)
            {
                for (int j = 0; j < build.Length; j++)
                {
                    if (!tmp.UpdateTile(build.X + i, build.Y + j, new BuildingTile(_world.Random,build)))
                    {
                        Console.WriteLine("Construction hors-limites !");
                        return false;
                    }
                }
            }
            _world = tmp;

            for (int i = 0; i < build.Workers; i++)
            {
                switch (build.GetType().Name)
                {
                    case "BuildersHouse":
                        _settlers.Add(new Builder(build.X, build.Y, build,_world));
                        break;
                    case "Longhouse":
                        _settlers.Add(new Villager(build.X, build.Y, build,_world));
                        break;
                    case "HuntersHut":
                        _settlers.Add(new Hunter(build.X, build.Y, build,_world));
                        break;
                    case "Mine":
                        _settlers.Add(new Miner(build.X, build.Y, build,_world));
                        break;
                    case "Workshop":
                        _settlers.Add(new Lumberjack(build.X, build.Y, build,_world));
                        break;
                }
            }
            _buildings.Add(build);
            _longhouse.ResourcesOwned.Wood -= build.Cost.Wood;
            _longhouse.ResourcesOwned.Stone -= build.Cost.Stone;
            _longhouse.ResourcesOwned.Food -= build.Cost.Food;
            b.Goal = new BuildingTile(_world.Random, build);
            b.GoingToGoal = true;
            return true;
        }
        /// <summary>
        /// Show further informations about a certain tile
        /// </summary>
        /// <param name="x">Row of tile (start to 1)</param>
        /// <param name="y">Column of tile (start to 1)</param>
        private void ShowInfos(int x, int y)
        {
            Console.WriteLine("Position : (x,y)=({0},{1})", x, y);
            Console.WriteLine(_world[x - 1, y - 1].Available);

            if (_world[x - 1, y - 1] is BuildingTile)
            {
                BuildingTile tile = _world[x - 1, y - 1] as BuildingTile;
                Console.WriteLine(tile.Build);
            }
        }
        /// <summary>
        /// Make every settler eat if possible
        /// </summary>
        private void CheckHunger()
        {
            foreach (Settler s in _settlers)
            {
                if (s is Villager v)
                {
                    if (_longhouse.ResourcesOwned.Food > 0)
                    {
                        v.Eat(true);
                        _longhouse.ResourcesOwned.Food -= 1;
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
                s.Move(_world.Random);
            }
        }
        /// <summary>
        /// Make every specialised settler pick resources if on it
        /// </summary>
        private void PickResources()
        {
            foreach (Settler s in _settlers)
            {
                if (s is Builder)
                {
                    Builder b = s as Builder;
                    b.Build();
                }
                else if (s is Hunter)
                {
                    Hunter h = s as Hunter;
                    h.CollectFood();
                }
                else if (s is Lumberjack)
                {
                    Lumberjack l = s as Lumberjack;
                    l.CutWood();
                }
                else if (s is Miner)
                {
                   Miner m = s as Miner;
                    m.PickStone();
                }
            }
        }
        /// <summary>
        /// Check if settlers are not dead and they give birth
        /// </summary>
        private void CheckLife()
        {
            //Check if still alive and remove all deads
            _settlers.RemoveAll(x => !x.Live(_world.Random));

            List<Settler> tmp = new List<Settler>(_settlers);
            //Check if gives birth
            foreach (Settler s in _settlers)
            {
                if (s.GiveBirth(_world.Random))
                    tmp.Add(new Villager(s.X, s.Y, _longhouse, _world));
            }
            _settlers = new List<Settler>(tmp);
        }
    }
}
