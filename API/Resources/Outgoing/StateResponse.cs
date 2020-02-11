using System.Collections.Generic;
using API.Entities;

namespace API.Resources.Outgoing
{
    public class StateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public string Country { get; set; }
        public List<string> Cities { get; set; }
    }
}