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
            CreateMap<Chassis, ChassisDto>().ReverseMap();
            CreateMap<Engine, EngineDto>().ReverseMap();
            CreateMap<Gearbox, GearboxDto>().ReverseMap();
            CreateMap<TireSet, TireSetDto>()
                .ForMember(t => t.Type, opt => opt.MapFrom(src => Mapper.tireTypeDict[src.Type]))
                .ReverseMap();
            CreateMap<RaceCar, RaceCarDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(s => s.UserTeamRole, opt => opt.MapFrom(src => Mapper.userRoleDict[src.UserTeamRole]))
                .ReverseMap();
            CreateMap<CarMechanic, CarMechanicDto>().ReverseMap();
            CreateMap<Driver, DriverDto>().ReverseMap();
            CreateMap<PitStopCrew, PitStopCrewDto>().ReverseMap();
            CreateMap<PitStopMechanic, PitStopMechanicDto>().ReverseMap();
            CreateMap<RaceEngineer, RaceEngineerDto>().ReverseMap();
            CreateMap<CarSession, CarSessionDto>()
                .ForMember(s => s.SessionType, opt => opt.MapFrom(src => Mapper.sessionTypeDict[src.SessionType]))
                .ReverseMap();
            CreateMap<CarSessionStartSpec, CarSessionStartSpecDto>()
                .ReverseMap();
            CreateMap<GrandPrix, GrandPrixDto>().ReverseMap();
            CreateMap<PitStop, PitStopDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
