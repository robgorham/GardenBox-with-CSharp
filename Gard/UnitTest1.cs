using System;
using GardenBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Gard
{
    [TestClass]
    public class UnitTest1
    {
        MyPlants myGardenBox = new MyPlants();
        List<Plant> plantlist = new List<Plant>();
        Plant somePlant;



        [TestMethod]
        public void SanityTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void AddOnePlantToGarden()
        {
            int count = 0;
            List<Plant> someP = new List<Plant>();
            someP.Add(new Plant("sunflower", 5));
            count = myGardenBox.AddPlantsToGardenBox(someP);
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void TestToStringOfPlant()
        {
            somePlant = new Plant("sun", 5);
            Assert.AreEqual($"Strain:sun Per Four Foot Square:5\n", somePlant.ToString());
        }

        [TestMethod]
        public void Calculate5SunFlower()
        {
            somePlant = new Plant("sun", 5);
            plantlist.Add(somePlant);
            plantlist.Add(new Plant("marigold", 10));
            myGardenBox.AddPlantsToGardenBox(plantlist);
            Assert.AreEqual(myGardenBox.CalculatePlanting(1), 10);
        }



        
    }
}
