using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Buildings
{
    class Longhouse : Building
    {
        Resources _stock;
        List<Villager> _listvillagers;

        // TO DO : Définir la dimension des bâtiments dans le "base"
        public Longhouse(int x, int y, int length, int width, Resources cost, int radius, int nbWorkers, Resources stock) : base(x, y, length, width, new Resources(0,0,0),radius,15)
        {
            _stock = stock;
            _listvillagers = new List<Villager>(nbWorkers);
        }


    }
}
