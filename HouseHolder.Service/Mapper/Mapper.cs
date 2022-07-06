using AutoMapper;
using HouseHolder.Entity;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace HouseHolder.Service.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Entity.HouseHolder, HouseHolderDto>().ReverseMap();
            CreateMap<Entity.HouseHolder, UpdateHouseHolderDto>().ReverseMap();
            CreateMap<Entity.HouseHolder, GetHouseHolderDto>().ReverseMap();
            CreateMap<HouseRequest, HouseRequestDto>().ReverseMap();
            CreateMap<HouseRequest, UpdateHouseRequestDto>().ReverseMap();
        }
    }
}