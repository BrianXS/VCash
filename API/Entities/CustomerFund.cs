using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class CustomerFund : IAuditable
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        
        public DateTime ClosedAt { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}