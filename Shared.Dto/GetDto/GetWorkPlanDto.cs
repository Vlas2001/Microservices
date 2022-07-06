using Shared.Dto.CreateDto;

namespace Shared.Dto.GetDto
{
    public class GetWorkPlanDto
    {
        public GetTeamDto Team { get; set; }
        
        public HouseRequestDto HouseRequest { get; set; }
    }
}