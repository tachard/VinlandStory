using Microsoft.VisualStudio.TestTools.UnitTesting;
using VinlandStory;
using VinlandStory.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Tests
{
    [TestClass()]
    public class VillagerTests
    {
        [TestMethod()]
        public void VillagerTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5,5,new Resources(0,0,0));
            Villager v = new Villager(5, 5, l, w);

            Assert.AreEqual(5, v.X);
            Assert.AreEqual(5, v.Y);
            Assert.AreEqual(0.4, v.Birth);
            Assert.AreEqual(0.2, v.Death);
            Assert.IsFalse(v.GoingToGoal);
            Assert.AreSame(l, v.Origin);
            Assert.IsNull(v.Goal);
            Assert.AreSame(w, v.World);
        }

        [TestMethod()]
        public void EatTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5, 5, new Resources(0, 0, 0));
            Villager v = new Villager(5, 5, l, w);

            v.Eat(false);
            Assert.AreEqual(0, v.Birth);
            Assert.AreEqual(0.6, v.Death);
            v.Eat(true);
            Assert.AreEqual(0.4, v.Birth);
            Assert.AreEqual(0.2, v.Death);
        }

        [TestMethod()]
        public void SetNewGoalTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5, 5, new Resources(0, 0, 0));
            Villager v = new Villager(5, 5, l, w);

            v.SetNewGoal();
            Assert.IsNull(v.Goal);
            Assert.IsFalse(v.GoingToGoal);
        }
    }
}