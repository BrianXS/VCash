using System;
using System.Collections.Generic;

namespace API.Entities.Administrative
{
    public class Country : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<State> States { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}