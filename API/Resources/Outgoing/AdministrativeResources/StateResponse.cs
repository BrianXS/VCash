using System.Collections.Generic;

namespace API.Resources.Outgoing.AdministrativeResources
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