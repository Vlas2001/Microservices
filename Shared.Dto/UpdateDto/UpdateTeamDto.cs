using System.Collections.Generic;

namespace Shared.Dto.UpdateDto
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        
        public string TeamName { get; set; }
        
        public List<int> WorkersId { get; set; } = new();

        public int RequestId { get; set; }
    }
}