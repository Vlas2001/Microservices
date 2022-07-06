using AutoMapper;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace WorkPlan.Service.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Entity.WorkPlan, WorkerDto>().ReverseMap();
            CreateMap<Entity.WorkPlan, GetWorkPlanDto>().ReverseMap();
            CreateMap<Entity.WorkPlan, UpdateWorkPlanDto>().ReverseMap();
        }
    }
}