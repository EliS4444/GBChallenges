using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan.Cars
{
    public enum VehicleType { sedan = 1, SUV, Truck, Van}
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public VehicleType Type { get; set; }
        public double AverageRange { get; set; }
        public string CarID
        {
            get
            {
                string ID = Year.ToString() + Make.ToLower() + Model.ToLower();
                return ID;
            }
        }

        public Car() { }
        public Car(string make, string model, int year)
        {
            Make = Make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, VehicleType type, double range)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            AverageRange = range;
        }
    }
}
