using Assignment.Classes;
using Moq;
using Xunit;

namespace Assignment.NUnitTests
{
    public class RaceCarTests
    {
        RaceCar car;
        CarMechanic mechanic;
        public void MockRaceCar()
        {
            var mockInfo = new Mock<RaceCar>();
            mockInfo.Object.Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" };
            mockInfo.Object.Engine = new Engine { Wear = 25, HorsePower = 1000 };
            mockInfo.Object.GearBox = new GearBox { Wear = 15 };

            mockInfo.Object.SetTotalWear();

            car = mockInfo.Object;
        }
        public void MockCarMechanic()
        {
            var mockInfo = new Mock<CarMechanic>();
            mockInfo.Object.Name = "Jeff";

            mechanic = mockInfo.Object;
        }
        [Fact]
        public void TestSetTotalWear()
        {
            MockRaceCar();

            car.SetTotalWear();

            Assert.True(20 == car.TotalWear);
        }
        [Fact]
        public void TestChassisFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car, car.Chassis);

            //Assert
            Assert.True(0 == car.Chassis.Wear);
        }
        [Fact]
        public void TestEngineFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car, car.Engine);

            //Assert
            Assert.True(0 == car.Engine.Wear);
        }
        [Fact]
        public void TestGearBoxFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car, car.GearBox);

            //Assert
            Assert.True(0 == car.GearBox.Wear);
        }
        [Fact]
        public void TestCarFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            mechanic.Fix(car);

            //Assert
            Assert.True(0 == car.TotalWear);
        }
    }
}
