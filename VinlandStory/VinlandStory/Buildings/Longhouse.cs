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
        List<Villager> _villagers;
        public Longhouse(int x, int y):base(x,y,2,2,new Resources(0, 0, 0), 0, 0) { }
    }
}
