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
        public void FixCar(RaceCar car, Part part)
        {
            if (car == null)
            {
                throw new NullReferenceException("Car is null");
            }
            if (part.Wear != 0)
            {
                throw new InvalidOperationException("Part is new!");
            }
            if (part is Chassis)
            {
                car.Chassis.Wear = 0;
            }
            else if (part is Engine)
            {
                car.Engine.Wear = 0;
            }
            else if (part is Gearbox)
            {
                car.Gearbox.Wear = 0;
            }
            else
            {
                throw new InvalidOperationException("Invalid part!");
            }
        }
    }
}
