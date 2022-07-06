using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HouseHolder.Entity;
using HouseHolder.Service.Abstraction;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;
using Shared.Repository;

namespace HouseHolder.Service.Implementation
{
    public class HouseRequestService: IHouseRequestService
    {
        const string DispatcherUrl = "https://localhost:5001";
        private readonly IRepository<HouseRequest> _houseRequestRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClient;

        public HouseRequestService(IRepository<HouseRequest> houseRequestRepository, 
            IMapper mapper, IHttpClientFactory httpClient)
        {
            _houseRequestRepository = houseRequestRepository;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task CreateRequestAsync(HouseRequestDto request)
        {
            await _houseRequestRepository.AddAsync(_mapper.Map<HouseRequestDto, HouseRequest>(request));
        }

        public async Task SendRequestAsync(int requestId, int dispatcherId)
        {
            JsonSerializer.Deserialize<bool>(
                await (await _httpClient.CreateClient()
                        .GetAsync(DispatcherUrl +
                                  $"/AddHouseRequest?requestId={requestId}&dispatcherId={dispatcherId}"))
                    .Content.ReadAsStringAsync(), 
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task EditHouseRequestAsync(UpdateHouseRequestDto houseRequestDto)
        {
            await _houseRequestRepository.EditAsync(_mapper.Map<UpdateHouseRequestDto, HouseRequest>(houseRequestDto));
        }

        public async Task DeleteHouseRequest(int id)
        {
            await _houseRequestRepository.DeleteAsync(id);
        }

        public async Task<HouseRequestDto> GetHouseRequestAsync(int id)
        {
            return _mapper.Map<HouseRequest, HouseRequestDto>(await _houseRequestRepository.GetAsync(id));
        }

        public async Task<List<HouseRequestDto>> GetAllHouseRequestsAsync()
        {
            var houseRequests = await _houseRequestRepository.GetAllAsync();
            return houseRequests.Select(houseRequest => _mapper.Map<HouseRequest, HouseRequestDto>(houseRequest)).ToList();
        }
    }
}