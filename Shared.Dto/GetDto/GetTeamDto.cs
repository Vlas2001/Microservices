using System.Collections.Generic;

namespace Shared.Dto.GetDto
{
    public class GetTeamDto
    {
        public string TeamName { get; set; }
        
        public List<GetWorkerDto> Workers { get; set; } = new();
    }
}