using System.Collections.Generic;
using Team.Entity;

namespace Entities
{
    public class Team
    {
        public int Id { get; set; }
        
        public string TeamName { get; set; }
        
        public List<Worker> Workers { get; set; } = new();
    }
}