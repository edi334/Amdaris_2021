using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Hare : Animal
    {
        public bool IsSleeping { get; set; }
        public string FurColor { get; set; }
        public Hare()
        {
            Diet = Diet.Herbivore;
            IsSleeping = false;
        }
        public override void Action()
        {
            Console.WriteLine("The hare ate a carrot!");
        }
        public void GoToSleep()
        {
            if (!IsSleeping)
            {
                IsSleeping = true;
                Console.WriteLine($"{Name} is going to sleep!");
                return;
            }
            Console.WriteLine($"{Name} is already sleeping.");
        }
        public void WakeUp()
        {
            if (IsSleeping)
            {
                IsSleeping = false;
                Console.WriteLine($"{Name} is awake.");
                return;
            }
            Console.WriteLine($"{Name} is not sleeping.");
        }
        public override string ToString()
        {
            return IsSleeping ? $"{Name} is a sleeping {FurColor} hare." : $"{Name} is a {FurColor} hare that is currently not sleeping.";
        }
    }
}
