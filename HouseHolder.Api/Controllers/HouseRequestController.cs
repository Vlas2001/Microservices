using System.Collections.Generic;
using System.Threading.Tasks;
using HouseHolder.Service;
using HouseHolder.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.CreateDto;
using Shared.Dto.UpdateDto;

namespace HouseHolder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseRequestController : ControllerBase
    {
        private readonly IHouseRequestService _houseRequestService;

        public HouseRequestController(IHouseRequestService houseRequestService)
        {
            _houseRequestService = houseRequestService;
        }
        
        [HttpPost("/CreateHouseRequest")]
        public async Task CreateHouseRequest(HouseRequestDto request)
        {
            await _houseRequestService.CreateRequestAsync(request);
        }

        [HttpPut("/SendHouseRequest")]
        public async Task SendHouseRequest(int requestId, int dispatcherId)
        {
            await _houseRequestService.SendRequestAsync(requestId, dispatcherId);
        }

        [HttpPut("/EditHouseRequest")]
        public async Task EditHouseRequest(UpdateHouseRequestDto houseRequestDto)
        {
            await _houseRequestService.EditHouseRequestAsync(houseRequestDto);
        }

        [HttpDelete("/DeleteHouseRequest")]
        public async Task DeleteHouseRequest(int id)
        {
            await _houseRequestService.DeleteHouseRequest(id);
        }

        [HttpGet("/GetHouseRequest")]
        public async Task<HouseRequestDto> GetHouseRequest(int id)
        {
            return await _houseRequestService.GetHouseRequestAsync(id);
        }

        [HttpGet("/GetAllHouseRequests")]
        public async Task<List<HouseRequestDto>> GetAllHouseRequests()
        {
            return await _houseRequestService.GetAllHouseRequestsAsync();
        }
    }
}