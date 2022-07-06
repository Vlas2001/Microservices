using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Shared.Repository;
using Team.Entity;
using Team.Service.Abstraction;

namespace Team.Service.Implementation
{
    public class TeamService: ITeamService
    {
        private readonly IRepository<Entities.Team> _teamRepository;
        private readonly IRepository<Worker> _workerRepository;
        private readonly IMapper _mapper;

        public TeamService(IRepository<Entities.Team> teamRepository, IMapper mapper, IRepository<Worker> workerRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _workerRepository = workerRepository;
        }

        public async Task CreateTeamAsync(TeamDto teamDto)
        {
            var workers = teamDto.WorkersId.Select(item => _workerRepository.GetAsync(item).Result).ToList();
            var team = _mapper.Map<TeamDto, Entities.Team>(teamDto);
            workers.ForEach(item => team.Workers.Add(item));
            await _teamRepository.AddAsync(team);
        }

        public async Task EditTeamAsync(UpdateTeamDto team)
        {
            await _teamRepository.EditAsync(_mapper.Map<UpdateTeamDto, Entities.Team>(team));
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
        }

        public async Task<GetTeamDto> GetTeamAsync(int id)
        {
            var team = _mapper.Map<Entities.Team, GetTeamDto>(await _teamRepository.GetAsync(id));
            var workers = await _workerRepository.GetAllAsync();
            var teamWorkers = workers
                .Where(item => item.Team != null && item.Team.Id == id)
                .Select(item => new GetWorkerDto
                {
                    Age = item.Age,
                    Name = item.Name,
                    Surname = item.Surname,
                    PhoneNumber = item.PhoneNumber,
                    TeamId = id
                });
            team.Workers.AddRange(teamWorkers);
            return team;
        }

        public async Task<List<GetTeamDto>> GetAllTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            var workers = await _workerRepository.GetAllAsync();
            return teams.Select(item => new GetTeamDto
            {
                TeamName = item.TeamName,
                Workers = workers.Where(worker => worker.Team != null && worker.Team.Id == item.Id)
                    .Select(worker => new GetWorkerDto
                    {
                        Age = worker.Age,
                        Name = worker.Name,
                        Surname = worker.Surname,
                        PhoneNumber = worker.PhoneNumber,
                        TeamId = worker.Team.Id
                    }).ToList()
            }).ToList();
        }
    }
}