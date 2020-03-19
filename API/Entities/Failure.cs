using System;

namespace API.Entities
{
    public class Failure : IAuditable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool ClientFault { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}