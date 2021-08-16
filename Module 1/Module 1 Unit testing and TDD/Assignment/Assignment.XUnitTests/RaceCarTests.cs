using System;
using Assignment.Classes;
using Moq;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTests
{
    public class RaceCarTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public RaceCarTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private RaceCar _car;
        private CarMechanic _mechanic;

        private void MockRaceCar()
        {
            var mockCar = new Mock<RaceCar>();

            mockCar.SetupAllProperties();
            mockCar.Object.Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" };
            mockCar.Object.Engine = new Engine { Wear = 15, HorsePower = 1000 };
            mockCar.Object.GearBox = new GearBox { Wear = 25, Gears = 8 };
            
            _car = mockCar.Object;
        }

        private void MockCarMechanic()
        {
            var mockMechanic = new Mock<CarMechanic>();
            mockMechanic.SetupAllProperties();
            mockMechanic.Object.Name = "Jeff";

            _mechanic = mockMechanic.Object;
        }
        [Fact]
        public void TestChassisFix()
        {
            //Arrange
            MockRaceCar();
            MockCarMechanic();

            //Act
            _mechanic.Fix(_car.Chassis);

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
            _mechanic.Fix(_car.Engine);

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
            _mechanic.Fix(_car.GearBox);

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
            _outputHelper.WriteLine(_car.TotalWear.ToString());
            _mechanic.Fix(_car);
            _outputHelper.WriteLine(_car.TotalWear.ToString());

            //Assert
            Assert.True(0 == _car.TotalWear);
        }
    }
}