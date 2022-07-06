using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HouseHolder.Entity;
using HouseHolder.Service.Abstraction;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Shared.Repository;

namespace HouseHolder.Service.Implementation
{
    public class HouseHolderService: IHouseHolderService
    {
        private readonly IRepository<Entity.HouseHolder> _houseHolderRepository;
        private readonly IRepository<HouseRequest> _houseRequestRepository;
        private readonly IMapper _mapper;

        public HouseHolderService(IRepository<Entity.HouseHolder> houseHolderRepository, IMapper mapper, IRepository<HouseRequest> houseRequestRepository)
        {
            _houseHolderRepository = houseHolderRepository;
            _mapper = mapper;
            _houseRequestRepository = houseRequestRepository;
        }

        public async Task AddHouseHolderAsync(HouseHolderDto householder)
        {
            await _houseHolderRepository.AddAsync(_mapper.Map<HouseHolderDto, Entity.HouseHolder>(householder));
        }

        public async Task DeleteHouseHolderAsync(int id)
        {
            await _houseHolderRepository.DeleteAsync(id);
        }

        public async Task EditHouseHolderAsync(UpdateHouseHolderDto houseHolderDto)
        {
            await _houseHolderRepository.EditAsync(_mapper.Map<UpdateHouseHolderDto, Entity.HouseHolder>(houseHolderDto));
        }
        public async Task<GetHouseHolderDto> GetHouseHolderAsync(int id)
        {
            var houseRequests = await _houseRequestRepository.GetAllAsync();
            var houseHolder = _mapper.Map<Entity.HouseHolder, GetHouseHolderDto>(await _houseHolderRepository.GetAsync(id));
            houseHolder.HouseRequest = _mapper.Map<HouseRequest, HouseRequestDto>(houseRequests.FirstOrDefault(item => item.HouseHolderId == id));
            return houseHolder;
        }

        public async Task<List<GetHouseHolderDto>> GetAllHouseHoldersAsync()
        {
            var houseRequests = await _houseRequestRepository.GetAllAsync();
            return _houseHolderRepository.GetAllAsync().Result.
                Select(item => new GetHouseHolderDto
            {
                Age = item.Age,
                Name = item.Name,
                Surname = item.Surname,
                PhoneNumber = item.PhoneNumber,
                HouseRequest = _mapper.Map<HouseRequest, HouseRequestDto>(houseRequests.FirstOrDefault(houseRequest => houseRequest.HouseHolderId == houseRequest.Id))
            }).ToList();
        }
    }
}