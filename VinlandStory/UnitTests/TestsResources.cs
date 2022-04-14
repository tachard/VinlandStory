using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VinlandStory;

namespace VinlandStory.Tests
{
    [TestClass()]
    public class TestsResources
    {
        [TestMethod()]
        public void ResourcesTest()
        {
            int food = 64;
            int stone = 78;
            int wood = 109;

            Resources test = new Resources(wood, stone, food);
            Assert.AreEqual(new Resources(wood, stone, food).ToString(), test.ToString());
        }

        [TestMethod()]
        public void ResourcesToStringTest()
        {
            int food = 64;
            int stone = 78;
            int wood = 109;

            Resources test = new Resources(wood, stone, food);
            Assert.AreEqual("Bois : 109\tPierre : 78\tNourriture : 64", test.ToString());
        }
    }
}