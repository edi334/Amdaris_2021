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
        public int TotalWear { get; set; }
        public void SetTotalWear()
        {
            TotalWear = (Chassis.Wear + Engine.Wear + GearBox.Wear) / 3;
        }
    }
}
