using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public Diet Diet { get; set; }
        public abstract void Action();
    }
}
