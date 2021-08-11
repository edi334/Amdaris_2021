using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models
{
    public class Session
    {
        public Session(string carId)
        {
            CarId = carId;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CarId { get; set; }
        public int Position { get; set; }
    }
}
