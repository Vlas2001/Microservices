using System.Collections.Generic;
using System.Threading.Tasks;
using HouseHolder.Service;
using HouseHolder.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace HouseHolder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseHolderController : ControllerBase
    {
        private readonly IHouseHolderService _houseHolderService;

        public HouseHolderController(IHouseHolderService houseHolderService)
        {
            _houseHolderService = houseHolderService;
        }

        [HttpPost("/AddHouseHolder")]
        public async Task AddHouseHolder(HouseHolderDto houseHolderDto)
        {
            await _houseHolderService.AddHouseHolderAsync(houseHolderDto);
        }

        [HttpDelete("/DeleteHouseHolder")]
        public async Task DeleteHouseHolder(int id)
        {
            await _houseHolderService.DeleteHouseHolderAsync(id);
        }

        [HttpPut("/EditHouseHolder")]
        public async Task EditHouseHolder(UpdateHouseHolderDto houseHolderDto)
        {
            await _houseHolderService.EditHouseHolderAsync(houseHolderDto);
        }

        [HttpGet("/GetHouseHolder")]
        public async Task<GetHouseHolderDto> GetHouseHolder(int id)
        {
            return await _houseHolderService.GetHouseHolderAsync(id);
        }

        [HttpGet("/GetAllHouseHolders")]
        public async Task<List<GetHouseHolderDto>> GetAllHouseHolders()
        {
            return await _houseHolderService.GetAllHouseHoldersAsync();
        }
    }
}