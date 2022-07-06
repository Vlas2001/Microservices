using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace WorkPlan.Service.Abstraction
{
    public interface IWorkPlanService
    {
        Task AddTeamAndRequestToWorkPlanAsync(int teamId, int requestId);

        Task EditWorkPlanItemAsync(UpdateWorkPlanDto workPlanDto);

        Task DeleteWorkPlanItemAsync(int id);

        Task<GetWorkPlanDto> GetWorkPlanItemAsync(int id);

        Task<List<GetWorkPlanDto>> GetWorkPlansAsync();
    }
}