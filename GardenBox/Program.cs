using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GardenBox
{




    class Program
    {

        /// <summary>
        /// getInt()
        /// grabs a non negative integer from the User through the Console
        /// </summary>
        /// <param name="prompt">Takes a String to display to User before readline</param>
        /// <returns>non Negative integer</returns>
        static int GetInt(string prompt)
        {
            int result = -1;
            string response = "";
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine();

            } while (!int.TryParse(response, out result));
            return result;
        }

        public static MyPlants GetPlantBed()
        {
            int width = GetInt("Please Enter in the Width");
            int length = GetInt("Please Enter in the Length");
            MyPlants plantBox = new MyPlants(length, width);
            return plantBox;
        }


        public static int GetPlantChoice(MyPlants plantBox)
        {
            int i = 0;
            foreach(Plant myPlant in plantBox.GetAllPlants())
            {
                Console.WriteLine($"[{i++}]{myPlant.PlantName}");
            }
            return GetInt("Please Enter the ID of the Plant");
        }

        static void Main(string[] args)
        {

            SqlConnection gardenDB = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\RINZLER\DOCUMENTS\ACADEMY\CODE\GARDENBOX\GARDENBOX.MDF;Integrated Security=True");
            gardenDB.Open();

            MyPlants plantbed = GetPlantBed();
            GardenBoxDB plantDATA = new GardenBoxDB(gardenDB);
            plantbed.AddPlantsToGardenBox(plantDATA.GetPlantList()); //add db to plantbed
            int plantchoice = GetPlantChoice(plantbed);
            Console.WriteLine($"You can plant {plantbed.CalculatePlanting(plantchoice)} {plantbed.GetAllPlants()[plantchoice]}");


            Console.ReadLine();
            gardenDB.Close();
        }
    }
}
