using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace HouseHolder.Service.Abstraction
{
    public interface IHouseHolderService
    {
        Task AddHouseHolderAsync(HouseHolderDto householder);

        Task DeleteHouseHolderAsync(int id);

        Task EditHouseHolderAsync(UpdateHouseHolderDto houseHolderDto);

        Task<GetHouseHolderDto> GetHouseHolderAsync(int id);

        Task<List<GetHouseHolderDto>> GetAllHouseHoldersAsync();
    }
}