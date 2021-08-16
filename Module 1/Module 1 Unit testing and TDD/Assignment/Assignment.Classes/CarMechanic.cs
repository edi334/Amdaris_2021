using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public class CarMechanic : Mechanic
    {
        public override void Fix(RaceCar car)
        {
            car.Chassis.Wear = 0;
            car.Engine.Wear = 0;
            car.GearBox.Wear = 0;

        }

        public void Fix(Part part)
        {
            part.Wear = 0;
        }
    }
}
