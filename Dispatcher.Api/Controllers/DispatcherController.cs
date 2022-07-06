using System.Collections.Generic;
using System.Threading.Tasks;
using Dispatcher.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;

namespace Dispatcher.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispatcherController : ControllerBase
    {
        private readonly IDispatcherService _dispatcherService;

        public DispatcherController(IDispatcherService dispatcherService)
        {
            _dispatcherService = dispatcherService;
        }

        [HttpPost("/AddDispatcher")]
        public async Task AddDispatcher(DispatcherDto dispatcherDto)
        {
            await _dispatcherService.AddDispatcherAsync(dispatcherDto);
        }

        [HttpPut("/EditDispatcher")]
        public async Task EditDispatcher(UpdateDispatcherDto dispatcherDto)
        {
            await _dispatcherService.EditDispatcherAsync(dispatcherDto);
        }

        [HttpDelete("/DeleteDispatcher")]
        public async Task DeleteDispatcher(int id)
        {
            await _dispatcherService.DeleteDispatcherAsync(id);
        }

        [HttpPut("/AddHouseRequest")]
        public async Task AddHouseRequest(int dispatcherId, int houseRequestId)
        {
            await _dispatcherService.AddHouseRequest(dispatcherId, houseRequestId);
        }

        [HttpGet("/GetDispatcher")]
        public async Task<DispatcherDto> GetDispatcher(int id)
        {
            return await _dispatcherService.GetDispatcherAsync(id);
        }

        [HttpGet("/GetAllDispatchers")]
        public async Task<List<DispatcherDto>> GetAllDispatchers()
        {
            return await _dispatcherService.GetAllDispatchersAsync();
        }
    }
}