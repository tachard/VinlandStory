using Microsoft.VisualStudio.TestTools.UnitTesting;
using VinlandStory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Tests
{
    [TestClass()]
    public class WorldTests
    {
        [TestMethod()]
        public void WorldTest()
        {
            World w = new World();
            Assert.AreEqual(30, w.Length);
            Assert.AreEqual(30, w.Width);
        }

        [TestMethod()]
        public void UpdateTileTest()
        {
            World w = new World();
            MeadowTile mtile = new MeadowTile(w.Random, 0, 0);

            w.UpdateTile(0, 0, mtile);
            Assert.AreSame(mtile, w[0, 0]);
        }
    }
}