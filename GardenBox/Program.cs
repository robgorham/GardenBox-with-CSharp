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



        static void Main(string[] args)
        {
            SqlConnection gardenDB = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\RINZLER\DOCUMENTS\ACADEMY\CODE\GARDENBOX\GARDENBOX.MDF;Integrated Security=True");
            gardenDB.Open();

            Console.ReadLine();
            gardenDB.Close();
        }
    }
}
