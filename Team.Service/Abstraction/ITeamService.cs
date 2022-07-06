using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace Team.Service.Abstraction
{
    public interface ITeamService
    {
        Task CreateTeamAsync(TeamDto team);

        Task EditTeamAsync(UpdateTeamDto team);

        Task DeleteTeamAsync(int id);

        Task<GetTeamDto> GetTeamAsync(int id);

        Task<List<GetTeamDto>> GetAllTeamsAsync();
    }
}