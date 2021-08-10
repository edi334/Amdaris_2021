using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Models
{
    class F1WorldChampion : F1DriverDecorator
    {
        public int Year { get; set; }
        public F1WorldChampion(F1Driver driver) : base(driver)
        {

        }
        public override void GetDescription()
        {
            base.GetDescription();
            Console.WriteLine($"I won the {Year} World Title!");
        }
    }
}
