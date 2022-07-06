using Shared.Entity;

namespace Team.Entity
{
    public class Worker: Person
    {
        public Entities.Team Team { get; set; }
    }
}