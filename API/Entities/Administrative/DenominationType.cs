using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities.Administrative
{
    public class DenominationType : IAuditable
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        
        public bool BankNote { get; set; }
        public bool NewSeries { get; set; }

        public int UnitsPerContainer { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }

        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}