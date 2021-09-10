using AutoMapper;
using F1Management.App.DtoModels;
using F1Management.App.DtoModels.CarDtos;
using F1Management.App.DtoModels.IdentityDtos;
using F1Management.App.DtoModels.TeamMemberDtos;
using F1Management.Core;
using F1Management.Core.Models;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chassis, ChassisDto>();
            CreateMap<Engine, EngineDto>();
            CreateMap<Gearbox, GearboxDto>();
            CreateMap<TireSet, TireSetDto>()
                .ForMember(t => t.Type, opt => opt.MapFrom(src => Mapper.tireTypeDict[src.Type]));
            CreateMap<RaceCar, RaceCarDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<CarMechanic, CarMechanicDto>();
            CreateMap<Driver, DriverDto>();
            CreateMap<PitStopCrew, PitStopCrewDto>();
            CreateMap<PitStopMechanic, PitStopMechanicDto>();
            CreateMap<RaceEngineer, RaceEngineerDto>();
            CreateMap<CarSession, CarSessionDto>()
                .ForMember(s => s.SessionType, opt => opt.MapFrom(src => Mapper.sessionTypeDict[src.SessionType]));
            CreateMap<GrandPrix, GrandPrixDto>();
            CreateMap<PitStop, PitStopDto>();
            CreateMap<Team, TeamDto>();
        }
    }
}
