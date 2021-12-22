using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan.Cars
{
    public class ElectricCar : Car
    {
        public double BatteryCapacity { get; set; }
        public double ChargeTime { get; set; }
        public string CarClassType
        {
            get
            {
                return "Electric Car";
            }
        }

        public ElectricCar() { }
        public ElectricCar(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public ElectricCar(string make, string model, int year, VehicleType type, double range, double battery, double charge)
        {
            Make = make;
            Model = model;  
            Year = year;    
            Type = type;
            AverageRange = range;
            BatteryCapacity = battery;
            ChargeTime = charge;
        }
    }
}
