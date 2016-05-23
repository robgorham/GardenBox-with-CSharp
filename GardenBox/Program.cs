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
        static void Main(string[] args)
        {
            SqlConnection gardenDB =  new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\RINZLER\DOCUMENTS\ACADEMY\CODE\GARDENBOX\GARDENBOX.MDF;Integrated Security=True");
            gardenDB.Open();
            Plant me = new Plant("rose", 5);
            Console.Write(me);

            Console.ReadLine();
            gardenDB.Close();
        }
    }
}
