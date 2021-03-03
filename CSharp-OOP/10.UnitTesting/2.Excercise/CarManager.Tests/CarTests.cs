namespace CarManager
{
    using CarManager;
    using NUnit.Framework;
    using System;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {

        }
        //Test1
        [Test]
        [TestCase("BMW", "M3", 10.5, 90.5)]
        public void CarShouldBeCreatedSuccessfully(
                                                    string make,
                                                    string model,
                                                    double fuelConsumption,
                                                    double fuelCapacity)
        {
            //Assert
            Car car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity);

            //Act - Action
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        //Test2
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakeCarPropertyException(string make)
        {
            //Assert - Acct - Action
            Assert.Throws<ArgumentException>(() => new Car(make, "M3", 10.5, 90.5));
        }

        //Test 3
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelCarPropertyException(string model)
        {
            //Assert - Acct - Action
            Assert.Throws<ArgumentException>(() => new Car("BMW", model, 10.5, 90.5));
        }

        //Test 4
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void FuelConsumptionCarPropertyException(double fuelConsumption)
        {
            //Assert - Acct - Action
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M3", fuelConsumption, 90.5));
        }

        //Test 5
        [Test]
        [TestCase(-20)]
        [TestCase(-10)]
        public void FuelCapacityCarPropertyException(double fuelCapacity)
        {
            //Assert - Acct - Action
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M3", 10.5, fuelCapacity));
        }

        //Test 6
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void FuelToRefuelThrowException(double fuelToRefuel)
        {
            //Arrange
            Car car = new Car("BMW", "M3", 10.5, 90.5);

            //Act - Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        //Test 7
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void AddFuelToFuelAmmount(double fuelToRefuel)
        {
            //Arrange
            Car car = new Car("BMW", "M3", 10.5, 90.5);

            //Act - Assert
            var expectedResult = fuelToRefuel + car.FuelAmount;
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        //Test 8
        [Test]
        [TestCase(120)]
        [TestCase(100)]
        public void IfFuleToRefuelIsMoreThanTheCapacityBothValuesShouldBeSimilar(double fuelToRefuel)
        {
            //Arrange
            Car car = new Car("BMW", "M3", 10.5, 90.5);

            //Act - Assert
            var expectedResult = car.FuelCapacity;
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        //Test 9 
        [Test]
        [TestCase(120)]
        [TestCase(100)]
        public void FuelNeededIsMoreThanActualFuelException(double distance)
        {
            //Arrange
            Car car = new Car("BMW", "M3", 10.5, 90.5);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        //Test 10
        [Test]
        [TestCase(120, 20)]
        [TestCase(100, 30)]
        public void FuelNeededToReduceFuelAmmount(double distance, double fuelToRefuel)
        {
            //Arrange
            Car car = new Car("BMW", "M3", 10.5, 90.5);

            //Act - Assert
            car.Refuel(fuelToRefuel);
            var fuelNeeded = (distance / 100) * car.FuelConsumption;
            var expectedResult = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}