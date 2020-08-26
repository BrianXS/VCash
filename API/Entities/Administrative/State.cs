using System;
using System.Collections.Generic;

namespace API.Entities.Administrative
{
    public class State : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<City> Cities { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}