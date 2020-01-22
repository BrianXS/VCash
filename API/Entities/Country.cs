using System.Collections.Generic;

namespace API.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<State> States { get; set; }
    }
}