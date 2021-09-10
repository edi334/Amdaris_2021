using F1Management.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class GrandPrix : BaseEntity
    {
        public string Name { get; set; }
        public string CircuitName { get; set; }
        [MaxLength(6)]
        public ICollection<CarSession> CarSessions { get; set; }
    }
}
