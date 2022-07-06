using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;

namespace HouseHolder.Service.Abstraction
{
    public interface IHouseRequestService
    {
        Task CreateRequestAsync(HouseRequestDto request);

        Task SendRequestAsync(int requestId, int dispatcherId);

        Task EditHouseRequestAsync(UpdateHouseRequestDto houseRequestDto);

        Task DeleteHouseRequest(int id);

        Task<HouseRequestDto> GetHouseRequestAsync(int id);

        Task<List<HouseRequestDto>> GetAllHouseRequestsAsync();
    }
}