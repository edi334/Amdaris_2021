using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Models
{
    abstract class F1DriverDecorator : Driver
    {
        protected F1Driver _driver;
        public F1DriverDecorator(F1Driver driver)
        {
            _driver = driver;
        }
        public override void GetDescription()
        {
            if (_driver != null)
            {
                _driver.GetDescription();
            }
            else
            {
                Console.WriteLine("F1Driver is null!");
            }
        }
    }
}
