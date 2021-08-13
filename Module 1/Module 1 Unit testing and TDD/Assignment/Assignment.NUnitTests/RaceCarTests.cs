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
            var mockInfo = new Mock<RaceCar>();
            mockInfo.Object.Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" };
            mockInfo.Object.Engine = new Engine { Wear = 25, HorsePower = 1000 };
            mockInfo.Object.GearBox = new GearBox { Wear = 15 };

            mockInfo.Object.SetTotalWear();

            _car = mockInfo.Object;
        }

        [SetUp]
        public void MockCarMechanic()
        {
            var mockInfo = new Mock<CarMechanic>();
            mockInfo.Object.Name = "Jeff";

            _mechanic = mockInfo.Object;
        }
        [TestCase]
        public void TestSetTotalWear()
        {
            MockRaceCar();

            _car.SetTotalWear();

            Assert.AreEqual(20, _car.TotalWear);
        }
        [TestCase]
        public void TestChassisFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car, _car.Chassis);

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
            _mechanic.Fix(_car, _car.Engine);

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
            _mechanic.Fix(_car, _car.GearBox);

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
