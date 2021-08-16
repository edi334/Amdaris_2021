using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public class RaceCar
    {
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public GearBox GearBox { get; set; }
        public int TotalWear  => (Chassis.Wear + Engine.Wear + GearBox.Wear) / 3;
        public override string ToString()
        {
            return $"{Chassis} {Engine} {GearBox} {TotalWear}";
        }
    }
}
