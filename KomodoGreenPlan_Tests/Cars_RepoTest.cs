using KomodoGreenPlan;
using KomodoGreenPlan.Cars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoGreenPlan_Tests
{
    [TestClass]
    public class Cars_RepoTest
    {
        [TestMethod]
        public void AddCar_ShouldGetCorrectBool()
        {
            HybridCar hybridCar = new HybridCar();
            Car_Repo repo = new Car_Repo();

            bool addResult = repo.AddCar(hybridCar);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllCars_ShouldReturnCorrectCollection()
        {
            GasCar car = new GasCar("Dodge","Ram",2021);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            
            List<Car> localCars = repo.GetAllCars();
            bool hasCar = localCars.Contains(car);

            Assert.IsTrue(hasCar);
        }

        [TestMethod]
        public void UpdateExistingCar_ShouldReturnCorrectCar()
        {
            GasCar car = new GasCar("Dodge", "Ram", 2021);
            HybridCar car2 = new HybridCar("Toyota","Prius",2020);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            repo.AddCar(car2);

            string id = "2021DodgeRam";

            var localCar = repo.GetCarByID(id);

            Assert.AreEqual(localCar.CarID, id);
        }

        [TestMethod]
        public void UpdateExistingCar_ShouldReturnTrue()
        {
            GasCar car = new GasCar("Dodge","Ram",2021);
            GasCar car2 = new GasCar("Nissan","Altima",2015,VehicleType.sedan,500,20);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            string id = "2021DodgeRam";

            bool UpdateResult = repo.UpdateExistingCar(id, car2);

            Assert.IsTrue(UpdateResult);
        }

        [TestMethod]
        public void DeleteCar()
        {
            GasCar car = new GasCar("Dodge","Ram",2021);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            string id = "2021DodgeRam";

            Car oldCar = repo.GetCarByID(id);
            bool removeResult = repo.DeleteCar(oldCar);

            Assert.IsTrue(removeResult);
        }


    }
}
