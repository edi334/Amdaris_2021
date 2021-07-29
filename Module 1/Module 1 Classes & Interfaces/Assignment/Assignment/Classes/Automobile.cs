using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class Automobile : Vehicle
    {
        public Automobile()
        {
            PassengerNumber = 1;
            Engine = "No engine";
        }
        public Automobile(int passengerNumber)
        {
            PassengerNumber = passengerNumber;
        }
        public Automobile(int passengerNumber, string engine) : this(passengerNumber)
        {
            Engine = engine;
        }
        public string Engine { get; set; }
        public int PassengerNumber { get; set; }
        public override string Action()
        {
            return "Automobile is running!";
        }
    }
}