using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dispatcher.Service.Abstraction;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;
using Shared.Repository;

namespace Dispatcher.Service.Implementation
{
    public class DispatcherService : IDispatcherService
    {
        private readonly IRepository<Entity.Dispatcher> _dispatcherRepository;
        private readonly IMapper _mapper;

        public DispatcherService(IRepository<Entity.Dispatcher> dispatcherRepository, IMapper mapper)
        {
            _dispatcherRepository = dispatcherRepository;
            _mapper = mapper;
        }

        public async Task AddDispatcherAsync(DispatcherDto dispatcher)
        {
            await _dispatcherRepository.AddAsync(_mapper.Map<DispatcherDto, Entity.Dispatcher>(dispatcher));
        }

        public async Task DeleteDispatcherAsync(int id)
        {
            await _dispatcherRepository.DeleteAsync(id);
        }

        public async Task EditDispatcherAsync(UpdateDispatcherDto dispatcherDto)
        {
            await _dispatcherRepository.EditAsync(_mapper.Map<UpdateDispatcherDto, Entity.Dispatcher>(dispatcherDto));
        }

        public async Task AddHouseRequest(int dispatcherId, int houseRequestId)
        {
            var dispatcher = await _dispatcherRepository.GetAsync(dispatcherId);
            dispatcher.HouseRequestIds.Add(houseRequestId);
            await _dispatcherRepository.EditAsync(dispatcher);
        }

        public async Task<DispatcherDto> GetDispatcherAsync(int id)
        {
            return _mapper.Map<Entity.Dispatcher, DispatcherDto>(await _dispatcherRepository.GetAsync(id));
        }

        public async Task<List<DispatcherDto>> GetAllDispatchersAsync()
        {
            var dispatchers = await _dispatcherRepository.GetAllAsync();
            return dispatchers.Select(dispatcher => _mapper.Map<Entity.Dispatcher, DispatcherDto>(dispatcher)).ToList();
        }
    }
}