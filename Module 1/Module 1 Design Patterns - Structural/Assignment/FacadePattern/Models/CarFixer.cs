using FacadePattern.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Models
{
    class CarFixer
    {
        public CarFixer(RaceCar car)
        {
            _car = car;
            _carMechanic = new CarMechanic(car.Chassis, car.Engine, car.Gearbox);
            _pitStopMechanic = new PitStopMechanic(car.Tires);
        }
        private CarMechanic _carMechanic;
        private PitStopMechanic _pitStopMechanic;
        private RaceCar _car;
        public void FixCar()
        {
            _carMechanic.Fix();
            _pitStopMechanic.Fix();
            _car.TotalWear = 0;
            
        }

        public void ChangeTyres(string type)
        {
            _pitStopMechanic.Fix(type);
            _car.TotalWear = 0;
        }
    }
}
