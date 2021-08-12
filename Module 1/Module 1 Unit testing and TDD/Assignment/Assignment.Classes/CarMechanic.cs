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

            car.SetTotalWear();
        }

        public void Fix(RaceCar car, Part part)
        {
            if (part is Chassis)
            {
                car.Chassis.Wear = 0;
            }
            else if (part is Engine)
            {
                car.Engine.Wear = 0;
            }
            else if (part is GearBox)
            {
                car.GearBox.Wear = 0;
            }
            else
            {
                throw new Exception("Invalid Part!");
            }

            car.SetTotalWear();
        }
    }
}
