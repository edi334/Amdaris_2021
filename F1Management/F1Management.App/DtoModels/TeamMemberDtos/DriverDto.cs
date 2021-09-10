using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.TeamMemberDtos
{
    public class DriverDto
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public int Number { get; set; }
        public int Points { get; set; }
        public Guid RaceCarId { get; set; }
    }
}
