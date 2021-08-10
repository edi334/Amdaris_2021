using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Models
{
    abstract class Mechanic
    {
        public string Name { get; set; }
        public abstract void Fix();
    }
}
