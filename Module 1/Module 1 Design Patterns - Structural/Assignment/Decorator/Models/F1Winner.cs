using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Models
{
    class F1Winner : F1DriverDecorator
    {
        public string RaceWon { get; set; }
        public F1Winner(F1Driver driver) : base(driver)
        {

        }
        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine($"I won {RaceWon}!");
        }
    }
}
