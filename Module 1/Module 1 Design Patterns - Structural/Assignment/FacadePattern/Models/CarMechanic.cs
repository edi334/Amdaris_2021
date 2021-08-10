using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Models.Car
{
    class CarMechanic : Mechanic
    {
        public CarMechanic(Chassis chassis, Engine engine, Gearbox gearbox)
        {
            if (chassis.Wear != 0)
            {
                _chassis = chassis;
            }
            if (engine.Wear != 0)
            {
                _engine = engine;
            }
            if (gearbox.Wear !=0)
            {
                _gearbox = gearbox;
            }
        }
        private Chassis _chassis;
        private Engine _engine;
        private Gearbox _gearbox;
        public override void Fix()
        {
            if (_chassis != null)
            {
                _chassis.Wear = 0;
                Console.WriteLine("Chassis fixed!");
            }
            if (_engine != null)
            {
                _engine.Wear = 0;
                Console.WriteLine("Engine fixed!");
            }
            if (_gearbox != null)
            {
                _gearbox.Wear = 0;
                Console.WriteLine("Gearbox fixed!");
            }
        }
    }
}
