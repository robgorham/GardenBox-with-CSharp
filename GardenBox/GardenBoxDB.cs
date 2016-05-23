using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GardenBox
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
            List<Plant> AvailablePlants = new List<Plant>();
            SqlCommand getPlantCommand = new SqlCommand("Select PlantName, PlantsPer16ft From PlantsStats", GardenDB);
            SqlDataReader getPlantReader = getPlantCommand.ExecuteReader();
                while (getPlantReader.Read())
                {
                    AvailablePlants.Add(new Plant(getPlantReader["PlantName"].ToString(), Int16.Parse(getPlantReader["PlantsPer16ft"].ToString())));
                }
           
            return AvailablePlants;
        }


    }
}
