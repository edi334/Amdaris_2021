using Assignment.Classes;
using Moq;
using NUnit.Framework;

namespace Assignment.NUnitTests
{
    [TestFixture]
    public class RaceCarTests
    {
        private RaceCar _car;
        private CarMechanic _mechanic;
        [SetUp]
        public void MockRaceCar()
        {
            var mockCar = new Mock<RaceCar>();

            mockCar.SetupAllProperties();
            mockCar.Object.Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" };
            mockCar.Object.Engine = new Engine { Wear = 15, HorsePower = 1000 };
            mockCar.Object.GearBox = new GearBox { Wear = 25, Gears = 8 };

            _car = mockCar.Object;
        }
        [SetUp]
        public void MockCarMechanic()
        {
            var mockMechanic = new Mock<CarMechanic>();
            mockMechanic.SetupAllProperties();
            mockMechanic.Object.Name = "Jeff";

            _mechanic = mockMechanic.Object;
        }
        [TestCase]
        public void TestChassisFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car.Chassis);

            //Assert
            Assert.AreEqual(0, _car.Chassis.Wear);
        }
        [TestCase]
        public void TestEngineFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car.Engine);

            //Assert
            Assert.AreEqual(0, _car.Engine.Wear);
        }
        [TestCase]
        public void TestGearBoxFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car.GearBox);

            //Assert
            Assert.AreEqual(0, _car.GearBox.Wear);
        }
        [TestCase]
        public void TestCarFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car);

            //Assert
            Assert.AreEqual(0, _car.TotalWear);
        }
    }
}
