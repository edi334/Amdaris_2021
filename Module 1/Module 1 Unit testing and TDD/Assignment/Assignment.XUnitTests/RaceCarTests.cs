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
        private RaceCar _car;
        private CarMechanic _mechanic;

        private void MockRaceCar()
        {
            _car = new RaceCar
            {
                Chassis = new Chassis { Wear = 20, FrontWing = "high downforce" },
                Engine = new Engine { Wear = 15, HorsePower = 1000 },
                GearBox = new GearBox { Wear = 25, Gears = 8 }
            };
        }
        private void MockCarMechanic()
        {
            _mechanic = new CarMechanic
            {
                Name = "Jeff"
            };
        }
        
        [Fact]
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
            _mechanic.Fix(_car);

            //Assert
            Assert.True(0 == _car.TotalWear);
        }
    }
}