using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan.Cars
{
    public class GasCar : Car
    {
        public double AvgMPG { get; set; }
        public string CarClassType
        {
            get 
            {
                return "Gas Car";
            }
        }

        public string V1 { get; }
        public string V2 { get; }
        public int V3 { get; }

        public GasCar() { }
        public GasCar(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public GasCar(string make, string model, int year, VehicleType type, double range, double mpg)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            AverageRange = range;
            AvgMPG = mpg;
        }

        
    }
}
