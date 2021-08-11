using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles.Mechanics
{
    public class CarMechanic : Mechanic
    {
        public override void FixCar(RaceCar car)
        {
            if (car == null)
            {
                throw new NullReferenceException("Car is null");
            }
            _updateParts(car);
            car.UpdateWear();
        }
        private void _updateParts(RaceCar car)
        {
            if (car.Chassis.Wear != 0)
            {
                car.Chassis.Wear = 0;
            }
            if (car.Engine.Wear != 0)
            {
                car.Engine.Wear = 0;
            }
            if (car.Gearbox.Wear != 0)
            {
                car.Gearbox.Wear = 0;
            }
        }
    }
}
