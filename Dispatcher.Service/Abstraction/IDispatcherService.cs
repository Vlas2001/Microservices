using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;

namespace Dispatcher.Service.Abstraction
{
    public interface IDispatcherService
    {
        Task AddDispatcherAsync(DispatcherDto dispatcher);
        Task DeleteDispatcherAsync(int id);
        Task EditDispatcherAsync(UpdateDispatcherDto dispatcherDto);
        Task AddHouseRequest(int dispatcherId, int houseRequestId);
        Task<DispatcherDto> GetDispatcherAsync(int id);
        Task<List<DispatcherDto>> GetAllDispatchersAsync();
    }
}