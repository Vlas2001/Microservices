using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Shared.Repository;
using WorkPlan.Service.Abstraction;

namespace WorkPlan.Service.Implementation
{
    public class WorkPlanService: IWorkPlanService
    {
        const string TeamUrl = "https://localhost:7001";
        const string HouseRequestUrl = "https://localhost:6001";
        
        
        private readonly IRepository<Entity.WorkPlan> _workPlanRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClient;

        public WorkPlanService(IRepository<Entity.WorkPlan> workPlanRepository, 
            IMapper mapper, IHttpClientFactory httpClient)
        {
            _workPlanRepository = workPlanRepository;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        
        public async Task AddTeamAndRequestToWorkPlanAsync(int teamId, int requestId)
        {
            await _workPlanRepository.AddAsync(new Entity.WorkPlan { RequestId = requestId, TeamId = teamId });
        }

        public async Task EditWorkPlanItemAsync(UpdateWorkPlanDto workPlanDto)
        {
            await _workPlanRepository.EditAsync(_mapper.Map<UpdateWorkPlanDto, Entity.WorkPlan>(workPlanDto));
        }

        public async Task DeleteWorkPlanItemAsync(int id)
        {
            await _workPlanRepository.DeleteAsync(id);
        }

        public async Task<GetWorkPlanDto> GetWorkPlanItemAsync(int id)
        {
            var workPlanItem = await _workPlanRepository.GetAsync(id);
            
            return new GetWorkPlanDto
            {
                Team = JsonSerializer.Deserialize<GetTeamDto>(await 
                    (await _httpClient.CreateClient().
                        GetAsync(TeamUrl + $"/GetTeam?id={workPlanItem.TeamId}")).
                    Content.ReadAsStringAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                }),
                HouseRequest = JsonSerializer.Deserialize<HouseRequestDto>(await 
                    (await _httpClient.CreateClient().
                        GetAsync(HouseRequestUrl + $"/GetHouseRequest?id={workPlanItem.RequestId}")).
                    Content.ReadAsStringAsync(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    }),
            };
        }

        public async Task<List<GetWorkPlanDto>> GetWorkPlansAsync()
        {
            var item = (await _workPlanRepository.GetAllAsync()).Select(plan => new GetWorkPlanDto
            {
                Team = JsonSerializer.Deserialize<GetTeamDto>(
                    _httpClient.CreateClient().GetAsync(TeamUrl + $"/GetTeam?id={plan.TeamId}").Result.Content
                        .ReadAsStringAsync().Result,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    }),
                HouseRequest = JsonSerializer.Deserialize<HouseRequestDto>(
                    _httpClient.CreateClient().GetAsync(HouseRequestUrl + $"/GetHouseRequest?id={plan.RequestId}")
                        .Result.Content.ReadAsStringAsync().Result,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    }),
            }).ToList();

            return item;
        }
    }   
}