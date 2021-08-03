using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Cat : Animal
    {
        public string Breed { get; set; }
        public Cat()
        {
            Diet = Diet.Carnivore;
        }
        public override void Action()
        {
            Console.WriteLine($"{Name} has jumped on the table.");
        }
        public override string ToString()
        {
            return $"{Name} is a {Breed} cat.";
        }
    }
}
