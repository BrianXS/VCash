using System;
using System.Collections.Generic;

namespace API.Entities.Administrative
{
    public class Branch : IAuditable
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public List<UserBranch> UserBranches { get; set; }
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}