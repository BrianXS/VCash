using System;

namespace API.Entities.Administrative
{
    public class City : IAuditable
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
        
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}