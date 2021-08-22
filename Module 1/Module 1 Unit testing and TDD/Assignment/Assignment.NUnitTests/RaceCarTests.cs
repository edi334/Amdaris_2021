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
            _car = new RaceCar
            {
                Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" },
                Engine = new Engine { Wear = 15, HorsePower = 1000 },
                GearBox = new GearBox { Wear = 25, Gears = 8 }
            };
        }
        [SetUp]
        public void MockCarMechanic()
        {
            _mechanic = new CarMechanic
            {
                Name = "Jeff"
            };
        }

        [TestCase]
        public void TestChassisBuilder()
        {
            //Arrange
            var chassisBuilder = new Mock<IChassisBuilder>();
            chassisBuilder.Setup(c => c.BuildChassis(It.IsAny<Chassis>())).Returns(true);
            var chassis = new Chassis(chassisBuilder.Object);
            
            //Act
            chassis.BuildChassis(new Chassis());
            
            //Assert
            chassisBuilder.Verify(c => c.BuildChassis(It.IsAny<Chassis>()), Times.Once());
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
