using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models
{
    public class PitStop : BaseEntity
    {
        public TireSet OldTires { get; set; }
        public Guid OldTiresId { get; set; }
        public TireSet NewTires { get; set; }
        public Guid NewTiresId { get; set; }
        public TimeSpan StationaryTime { get; set; }
        public Guid CarSessionId { get; set; }
        public CarSession Session { get; set; }
    }
}
