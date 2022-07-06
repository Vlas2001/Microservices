using Shared.Entity.Enums;

namespace Shared.Dto.CreateDto
{
    public class HouseRequestDto
    {
        public int HouseHolderId { get; set; }
        
        public WorkType WorkType { get; set; }
        
        public WorkScale WorkScale { get; set; }
        
        public int WorkTime { get; set; }
    }
}