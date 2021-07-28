using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class Car
    {
        static Car()
        {
            CarCount = 1;
            Console.WriteLine("Static constructor says there is already a car in the garage!");
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public void Write()
        {
            Console.WriteLine("The car is a " + Brand + " " + Name + ".");
        }
        public void CheckNameNoRef(string name, bool areSame)
        {
            areSame = Name == name;
        }
        public void CheckNameRef(string name, ref bool areSame)
        {
            areSame = Name == name;
        }
        public void CheckNameOut(string name, out bool areSame)
        {
            areSame = Name == name;
        }
        public void CheckNameRefType (string name, bool? areSameRef)
        {
            areSameRef = Name == name;
        }
        public static int CarCount { get; set; }
        public static void StartCar()
        {
            Console.WriteLine("Starting engine!");
        }
        public static void Prepare()
        {
            Console.WriteLine("Preparing garage!");
        }
    }
}
