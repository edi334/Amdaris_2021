using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    abstract class Vehicle
    {
        public Vehicle() 
        {
            WheelsCount = 4;
        }
        public Vehicle(int wheelsCount)
        {
            WheelsCount = wheelsCount;
        }
        public int WheelsCount { get; set; }
        public int Price { get; set; }
        public abstract string Action();
    }
}
