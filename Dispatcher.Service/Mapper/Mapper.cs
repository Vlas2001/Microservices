using System.Collections.Generic;
using AutoMapper;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;

namespace Dispatcher.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Dispatcher, DispatcherDto>().ReverseMap().
                ForMember(item => item.HouseRequestIds, expression => expression.MapFrom(item => new List<int>()));
            CreateMap<Entity.Dispatcher, UpdateDispatcherDto>().ReverseMap();
        }
    }
}