using System;
using GardenBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        public void ValidateFirstandSecondInserts()
        {
            plantlist.Add(new Plant("sun", 5));
            plantlist.Add(new Plant("marigold", 10));
            myGardenBox.AddPlantsToGardenBox(plantlist);
            Assert.AreEqual(myGardenBox.CalculatePlanting(1), 10);
            Assert.AreEqual(myGardenBox.CalculatePlanting(0), 5);

        }


        [TestMethod]
        public void ValidateBiggerBox()
        {
            plantlist.Add(new Plant("sun", 5));
            plantlist.Add(new Plant("marigold", 10));
            myGardenBox = new MyPlants(8, 8);
            myGardenBox.AddPlantsToGardenBox(plantlist);
            Assert.AreEqual(myGardenBox.CalculatePlanting(1), 40);
            Assert.AreEqual(myGardenBox.CalculatePlanting(0), 20);
        }




    }


    [TestClass]
    public class GardenBoxDBTest
    {
        SqlConnection myConn;
        GardenBoxDB GBDB;

        public GardenBoxDBTest()
        {
            myConn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\RINZLER\DOCUMENTS\ACADEMY\CODE\GARDENBOX\GARDENBOX.MDF;Integrated Security=True");
            myConn.Open();
            GBDB = new GardenBoxDB(myConn);

        }

        ~GardenBoxDBTest()
        {
            myConn.Close();
        }

        [TestMethod]

        public void GrabPlantsSizeIs3()
        {
            List<Plant> plantlist=GBDB.GetPlantList();
            Assert.AreEqual(plantlist.Count, 3);
        }

        [TestMethod]
        public void SanityinDB()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
