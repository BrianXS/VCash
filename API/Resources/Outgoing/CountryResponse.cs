using System.Collections.Generic;

namespace API.Resources.Outgoing
{
    public class CountryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<string> States { get; set; }
        public List<string> Cities { get; set; }
    }
}