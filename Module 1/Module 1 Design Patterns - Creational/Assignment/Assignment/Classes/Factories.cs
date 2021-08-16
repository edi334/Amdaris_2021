using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public class DriverFactory
    {
        public Driver CreateNewDriver(string name, int points, int wins)
        {
            var driver = new Driver
            {
                Name = name,
                Points = points,
                Wins = wins
            };

            return driver;
        }
    }
    public class CarFactory
    {
        private DriverFactory _driverFactory;
        public CarFactory(DriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
        }
        public Car CreateNewCar(string name, string team, int horsePower, string chassis,
            string driverName, int driverPoints, int driverWins)
        {
            var driver = _driverFactory.CreateNewDriver(driverName, driverPoints, driverWins);

            var car = new Car
            {
                Name = name,
                Team = team,
                HorsePower = horsePower,
                Chassis = chassis,
                Driver = driver
            };

            return car;
        }
    }
    
}
