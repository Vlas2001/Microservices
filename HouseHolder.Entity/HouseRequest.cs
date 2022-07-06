using Shared.Entity.Enums;

namespace HouseHolder.Entity
{
    public class HouseRequest
    {
        public int Id { get; set; }
        
        public WorkType WorkType { get; set; }
        
        public WorkScale WorkScale { get; set; }
        
        public int WorkTime { get; set; }
        
        public bool IsFormed { get; set; }
        
        public int HouseHolderId { get; set; }
    }
}
