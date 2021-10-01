using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Mapper
{
    public static class Mapper
    {
        public static Dictionary<TireType, string> tireTypeDict = new Dictionary<TireType, string>
        {
            { TireType.Soft, "Soft" },
            { TireType.Medium,  "Medium" },
            { TireType.Hard,  "Hard" },
            { TireType.Intermediate, "Intermediate" },
            { TireType.Wet, "Wet" }
        };

        public static Dictionary<SessionType, string> sessionTypeDict = new Dictionary<SessionType, string>
        {
            { SessionType.FP1, "FP1" },
            { SessionType.FP2, "FP2" },
            { SessionType.FP3, "FP3" },
            { SessionType.Qualifying, "Qualifying" },
            { SessionType.Race, "Race" },
            { SessionType.SprintRace, "SprintRace" }
        };

        public static Dictionary<UserTeamRole, string> userRoleDict = new Dictionary<UserTeamRole, string>
        {
            { UserTeamRole.Driver, "Driver" },
            { UserTeamRole.CarMechanic, "CarMechanic" },
            { UserTeamRole.PitStopMechanic, "PitStopMechanic" },
            { UserTeamRole.RaceEngineer, "RaceEngineer" },
        };
    }
}
