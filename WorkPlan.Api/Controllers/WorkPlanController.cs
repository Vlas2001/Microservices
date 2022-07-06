using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using WorkPlan.Service.Abstraction;

namespace WorkPlan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkPlanController : ControllerBase
    {
        private readonly IWorkPlanService _workPlanService;

        public WorkPlanController(IWorkPlanService workPlanService)
        {
            _workPlanService = workPlanService;
        }
        
        [HttpPost("/AddWorkPlanItem")]
        public async Task AddTeamAndRequestToWorkPlan(int teamId, int requestId)
        {
            await _workPlanService.AddTeamAndRequestToWorkPlanAsync(teamId, requestId);
        }

        [HttpPut("/EditWorkPlanItem")]
        public async Task EditWorkPlanItem(UpdateWorkPlanDto workPlanDto)
        {
            await _workPlanService.EditWorkPlanItemAsync(workPlanDto);
        }

        [HttpDelete("/DeleteWorkPlanItem")]
        public async Task DeleteWorkPlanItem(int id)
        {
            await _workPlanService.DeleteWorkPlanItemAsync(id);
        }

        [HttpGet("/GetWorkPlanItem")]
        public async Task<GetWorkPlanDto> GetWorkPlanItem(int id)
        {
            return await _workPlanService.GetWorkPlanItemAsync(id);
        }

        [HttpGet("/GetWorkPlan")]
        public async Task<List<GetWorkPlanDto>> GetWorkPlans()
        {
            return await _workPlanService.GetWorkPlansAsync();
        }
    }
}