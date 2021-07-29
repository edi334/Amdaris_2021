using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class Car : Automobile
    {
        public Car() { }
        public Car(string name, string brand)
        {
            Name = name;
            Brand = brand;
        }
        public string Name { get; set; }
        public string Brand { get; set; }
        public override string ToString()
        {
            return $"This {Brand} {Name} has {WheelsCount} wheels, a {Engine} engine and can hold {PassengerNumber} passengers!";
        }
        public override string Action()
        {
            return $"{Brand} {Name} has exceeded 150 mph!";
        }
    }
}
