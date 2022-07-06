using AutoMapper;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Team.Entity;

namespace Team.Service.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Entities.Team, TeamDto>().ReverseMap();
            CreateMap<Worker, WorkerDto>().ReverseMap();
            CreateMap<Entities.Team, UpdateTeamDto>().ReverseMap();
            CreateMap<Worker, UpdateWorkerDto>().ReverseMap();
            CreateMap<Worker, GetWorkerDto>().ReverseMap();
            CreateMap<Entities.Team, GetTeamDto>().ReverseMap();
        }
    }
}