using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Models.Car
{
    class PitStopMechanic : Mechanic
    {
        private List<Tire> _tires;
        public PitStopMechanic(List<Tire> tires)
        {
            _tires = tires;
        }
        public override void Fix()
        {
            _tires.ForEach(t => t.Wear = 0);
            Console.WriteLine("Tires changed!");

        }
        public void Fix(string type)
        {
            _tires.ForEach(t =>
            {
                t.Wear = 0;
                t.Type = type;
            });
            Console.WriteLine($"Tires changed! New compound is: {type}!");
        }
    }
}
