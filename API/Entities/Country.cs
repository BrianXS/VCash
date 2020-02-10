using System.Collections.Generic;

namespace API.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<State> States { get; set; }
    }
}