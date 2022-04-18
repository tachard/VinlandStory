using Microsoft.VisualStudio.TestTools.UnitTesting;
using VinlandStory.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinlandStory.Tests
{
	[TestClass()]
	public class TestsTile
	{
		[TestMethod()]
		public void BuildingTileTest()
		{
			Random r = new Random();
			Longhouse l = new Longhouse(3, 4, new Resources(0, 0, 0));

			BuildingTile tile = new BuildingTile(r, l);
			Assert.AreEqual(new Resources(0,0,0).ToString(),tile.Available.ToString());
			Assert.AreEqual(3, tile.X);
			Assert.AreEqual(4, tile.Y);
			Assert.AreEqual(l, tile.Build);
		}

		[TestMethod()]
		public void PrintBuildingTileTest()
		{
			Random r = new Random();
			Longhouse l = new Longhouse(3, 4, new Resources(0, 0, 0));

			BuildingTile tile = new BuildingTile(r, l);
			tile.PrintTile();

			Assert.AreEqual(ConsoleColor.Gray, Console.ForegroundColor);
			Assert.AreEqual(ConsoleColor.Black, Console.BackgroundColor);
			
		}

		[TestMethod()]
		public void MeadowTileTest()
		{
			Random r = new Random();
			MeadowTile mtile = new MeadowTile(r, 5, 5);
			bool result = (mtile.Available.Food >= 100 && mtile.Available.Food < 140);
			Assert.AreEqual(true, result);
		}
	}
}