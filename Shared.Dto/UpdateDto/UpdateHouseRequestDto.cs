using Shared.Entity.Enums;

namespace Shared.Dto.UpdateDto
{
    public class UpdateHouseRequestDto
    {
        public int Id { get; set; }
        
        public int HouseHolderId { get; set; }
        
        public WorkType WorkType { get; set; }
        
        public WorkScale WorkScale { get; set; }
        
        public int WorkTime { get; set; }
    }
}