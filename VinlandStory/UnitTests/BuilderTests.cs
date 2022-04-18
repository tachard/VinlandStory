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
    public class BuilderTests
    {
        [TestMethod()]
        public void BuilderTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5,5,new Resources(0,0,0));
            BuildersHouse bh = new BuildersHouse(5, 5, l);

            Builder b = new Builder(5, 5, bh, w);

            Assert.AreEqual(5, b.X);
            Assert.AreEqual(5, b.Y);
            Assert.AreEqual(0, b.Birth);
            Assert.AreEqual(0, b.Death);
            Assert.AreSame(bh, b.Origin);
            Assert.AreSame(w, b.World);
            Assert.IsNull(b.Goal);
            Assert.IsFalse(b.GoingToGoal);
        }

        [TestMethod()]
        public void BuildTest()
        {
            World w = new World();
            Longhouse l = new Longhouse(5, 5, new Resources(0, 0, 0));
            BuildersHouse bh = new BuildersHouse(5, 5, l);
            BuildersHouse nbh = new BuildersHouse(6, 6, l);
            BuildingTile btile = new BuildingTile(w.Random, nbh);
            Builder b = new Builder(5, 5, bh, w);

            b.SetNewGoal(btile);
            Assert.AreSame(btile, b.Goal);
            Assert.IsTrue(b.GoingToGoal);

            b.Move(w.Random);
            b.Build();
            Assert.IsNull(b.Goal);
            Assert.IsFalse(b.GoingToGoal);
        }
    }
}