using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles.Mechanics
{
    class PitStopMechanic : Mechanic
    {
        public override void FixCar(RaceCar car)
        {
            if (car == null)
            {
                throw new NullReferenceException("Car is null");
            }
            car.Tires.ForEach(t => t.Wear = 0);
        }
        public void FixCar(RaceCar car, TireType type)
        {
            if (car == null)
            {
                throw new NullReferenceException("Car is null");
            }
            car.Tires.ForEach(t => {
                t.Wear = 0;
                t.Type = type;
            });
        }
    }
}
