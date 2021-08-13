using Assignment.Classes;
using Moq;
using Xunit;

namespace Assignment.NUnitTests
{
    public class RaceCarTests
    {
        private RaceCar _car;
        private CarMechanic _mechanic;
        private void MockRaceCar()
        {
            var mockInfo = new Mock<RaceCar>();
            mockInfo.Object.Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" };
            mockInfo.Object.Engine = new Engine { Wear = 25, HorsePower = 1000 };
            mockInfo.Object.GearBox = new GearBox { Wear = 15 };

            mockInfo.Object.SetTotalWear();

            _car = mockInfo.Object;
        }
        private void MockCarMechanic()
        {
            var mockInfo = new Mock<CarMechanic>();
            mockInfo.Object.Name = "Jeff";

            _mechanic = mockInfo.Object;
        }
        [Fact]
        public void TestSetTotalWear()
        {
            MockRaceCar();

            _car.SetTotalWear();

            Assert.True(20 == _car.TotalWear);
        }
        [Fact]
        public void TestChassisFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car, _car.Chassis);

            //Assert
            Assert.True(0 == _car.Chassis.Wear);
        }
        [Fact]
        public void TestEngineFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car, _car.Engine);

            //Assert
            Assert.True(0 == _car.Engine.Wear);
        }
        [Fact]
        public void TestGearBoxFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car, _car.GearBox);

            //Assert
            Assert.True(0 == _car.GearBox.Wear);
        }
        [Fact]
        public void TestCarFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car);

            //Assert
            Assert.True(0 == _car.TotalWear);
        }
    }
}
