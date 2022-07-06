using System.Collections.Generic;

namespace Shared.Dto.CreateDto
{
    public class TeamDto
    {
        public string TeamName { get; set; }
        
        public List<int> WorkersId { get; set; } = new();
    }
}