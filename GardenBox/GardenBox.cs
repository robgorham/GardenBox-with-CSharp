using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenBox
{
    public class Plant
    {
        public string PlantName { get; }
        public int PlantsPer16Feet { get;}

        public Plant(string PlantName, int PlantsPer16Feet)
        {
            this.PlantName = PlantName;
            this.PlantsPer16Feet = PlantsPer16Feet;
        }

        public override string ToString()
        {
            return $"{PlantName}\n";
        }


    }
    public class MyPlants
    {
        private int length;
        private int width;
        private int area { get; }
        private int perimeter { get; }
        private List<Plant> myGarden;

        public MyPlants(int length = 4, int width = 4)
        {
            myGarden = new List<Plant>();
            this.length = length;
            this.width = width;
            this.area = length * width;
            this.perimeter = (length *2) + (width * 2);
        }

        public int AddPlantsToGardenBox(List<Plant> addplants)
        {
            myGarden = new List<Plant>(addplants);
            return myGarden.Count;
        }

        public List<Plant> GetAllPlants()
        {
            return myGarden;
        }

        public double CalculatePlanting( int plantIndex)
        {
            Plant currPlant = myGarden[plantIndex];
            return ((1.0 * currPlant.PlantsPer16Feet / 16)*area);
        }
    }

    
}

