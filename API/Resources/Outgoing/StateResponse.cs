using System.Collections.Generic;
using API.Entities;

namespace API.Resources.Outgoing
{
    public class StateResponse
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<City> Cities { get; set; }
    }
}