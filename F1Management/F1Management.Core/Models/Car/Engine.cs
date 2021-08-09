using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    class Engine : Part
    {
        public string Brand { get; set; }
        public int HorsePower { get; set; }
    }
}
