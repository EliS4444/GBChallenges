using KomodoGreenPlan.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class Car_Repo
    {
        private List<Car> _repo = new List<Car>(); 

        public bool AddCar(Car car)
        {
            int startingCount = _repo.Count;
            _repo.Add(car);
            bool wasAdded = (_repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Car> GetAllCars()
        {
            return _repo;
        }

        public Car GetCarByID(string ID)
        {
            foreach (Car car in _repo)
            {
                if (car.CarID == ID)
                {
                    return car;
                }
            }
            return null;
        }

        public bool UpdateExistingCar(string id, Car newCar)
        {
            var oldCar = GetCarByID(id);
            if (oldCar != null)
            {
                if (oldCar is HybridCar)
                {
                    ((HybridCar)oldCar).AvgMPG = ((HybridCar)newCar).AvgMPG;
                    ((HybridCar)oldCar).BatteryCapacity = ((HybridCar)newCar).BatteryCapacity;
                }
                else if (oldCar is GasCar)
                {
                    ((GasCar)oldCar).AvgMPG = ((GasCar)newCar).AvgMPG;
                }
                else if (oldCar is ElectricCar)
                {
                    ((ElectricCar)oldCar).BatteryCapacity = ((ElectricCar)newCar).BatteryCapacity;
                    ((ElectricCar)oldCar).ChargeTime = ((ElectricCar)newCar).ChargeTime;
                }

                oldCar.Make = newCar.Make;
                oldCar.Model = newCar.Model;
                oldCar.Year = newCar.Year;
                oldCar.Type = newCar.Type;
                oldCar.AverageRange = newCar.AverageRange;

                return true;
            }

            else { return false; }
        }

        public bool DeleteCar(Car car)
        {
            bool deleteCar = _repo.Remove(car);
            return deleteCar;
        }
    }
}
