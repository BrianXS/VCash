using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class CustomerFund
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public DateTime ClosedAt { get; set; }
    }
}