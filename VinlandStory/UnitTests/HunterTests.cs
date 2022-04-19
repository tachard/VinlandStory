using Microsoft.VisualStudio.TestTools.UnitTesting;
using VinlandStory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinlandStory.Buildings;

namespace VinlandStory.Tests
{
    [TestClass()]
    public class HunterTests
    {
        [TestMethod()]
        public void HunterTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5, 5, new Resources(0, 0, 0));
            HuntersHut hh = new HuntersHut(6, 6, l);

            Hunter h = new Hunter(6, 6, hh, w);

            Assert.AreEqual(0, h.Food);
            h.Food = 400;
            Assert.IsTrue(h.IsFull());
        }

        [TestMethod()]
        public void CollectFoodTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5, 5, new Resources(0, 0, 0));
            HuntersHut hh = new HuntersHut(6, 6, l);

            Hunter h = new Hunter(6, 6, hh, w);

            while(h.X != h.Goal.X || h.Y != h.Goal.Y)
                h.Move(w.Random);

            Assert.AreEqual(0, h.Food);
            h.CollectFood();
            Assert.AreEqual(60, h.Food);

            h.Food = 400;
            h.GoingToGoal = false;
            while(h.X!=h.Origin.X || h.Y!=h.Origin.Y)
                h.Move(w.Random);
            h.CollectFood();
            Assert.AreEqual(0, h.Food);
            Assert.AreEqual(400, h.Origin.Longhouse.ResourcesOwned.Food);
        }
    }
}