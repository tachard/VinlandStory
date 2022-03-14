using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tile test
            Random r = new Random();
            Console.OutputEncoding = Encoding.Unicode;

            MeadowTile t1 = new MeadowTile(r);
            Console.WriteLine(t1.Available);
            t1.PrintTile();
            Console.Clear();
            Console.ResetColor();

            ForestTile t2 = new ForestTile(r);
            Console.WriteLine(t2.Available);
            t2.PrintTile();
            Console.Clear();
            Console.ResetColor();

            DepositTile t3 = new DepositTile(r);
            Console.WriteLine(t3.Available);
            t3.PrintTile();
            Console.Clear();
            Console.ResetColor();

            BuildingTile t4 = new BuildingTile(r);
            Console.WriteLine(t4.Available);
            t4.PrintTile();
            Console.Clear();
            Console.ResetColor();

            //World test
            World w1 = new World();
            w1.PrintWorld();
        }
    }
}
