using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GardenBoxDB
{
    public class GardenBoxDB
    {
        SqlConnection GardenDB;
        public GardenBoxDB(SqlConnection myconnect)
        {
            GardenDB = myconnect;
        }

        public List<Plant> GetPlantList()
        {

        }


    }
}
