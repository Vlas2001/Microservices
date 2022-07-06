using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entity;

namespace Dispatcher.Entity
{
    public class Dispatcher: Person
    {
        [NotMapped]
        public List<int> HouseRequestIds { get; set; } = new();
    }
}