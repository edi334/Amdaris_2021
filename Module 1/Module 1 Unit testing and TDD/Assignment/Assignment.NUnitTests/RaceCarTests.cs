using Assignment.Classes;
using Moq;
using NUnit.Framework;

namespace Assignment.NUnitTests
{
    [TestFixture]
    public class RaceCarTests
    {
        RaceCar car;
        CarMechanic mechanic;
        [SetUp]
        public void MockRaceCar()
        {
            var mockInfo = new Mock<RaceCar>();
            mockInfo.Object.Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" };
            mockInfo.Object.Engine = new Engine { Wear = 25, HorsePower = 1000 };
            mockInfo.Object.GearBox = new GearBox { Wear = 15 };

            mockInfo.Object.SetTotalWear();

            car = mockInfo.Object;
        }

        [SetUp]
        public void MockCarMechanic()
        {
            var mockInfo = new Mock<CarMechanic>();
            mockInfo.Object.Name = "Jeff";

            mechanic = mockInfo.Object;
        }
        [TestCase]
        public void TestSetTotalWear()
        {
            MockRaceCar();

            car.SetTotalWear();

            Assert.AreEqual(20, car.TotalWear);
        }
        [TestCase]
        public void TestChassisFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car, car.Chassis);

            //Assert
            Assert.AreEqual(0, car.Chassis.Wear);
        }
        [TestCase]
        public void TestEngineFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car, car.Engine);

            //Assert
            Assert.AreEqual(0, car.Engine.Wear);
        }
        [TestCase]
        public void TestGearBoxFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car, car.GearBox);

            //Assert
            Assert.AreEqual(0, car.GearBox.Wear);
        }
        [TestCase]
        public void TestCarFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car);

            //Assert
            Assert.AreEqual(0, car.TotalWear);
        }
    }
}
