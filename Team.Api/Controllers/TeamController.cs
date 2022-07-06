using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Team.Service.Abstraction;

namespace Team.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        
        [HttpPost("/CreateTeam")]
        public async Task CreateTeam(TeamDto team)
        {
            await _teamService.CreateTeamAsync(team);
        }

        [HttpPut("/EditTeam")]
        public async Task EditTeam(UpdateTeamDto team)
        {
            await _teamService.EditTeamAsync(team);
        }

        [HttpDelete("/DeleteTeam")]
        public async Task DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
        }

        [HttpGet("/GetTeam")]
        public async Task<GetTeamDto> GetTeam(int id)
        {
            return await _teamService.GetTeamAsync(id);
        }

        [HttpGet("/GetAllTeams")]
        public async Task<List<GetTeamDto>> GetAllTeams()
        {
            return await _teamService.GetAllTeamsAsync();
        }
    }
}