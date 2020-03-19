using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class EnvelopeDenomination : IAuditable
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        public int DenominationTypeId { get; set; }
        public DenominationType DenominationType { get; set; }

        public int Bundle { get; set; }
        public int Singles { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCountedCash { get; set; }

        public int EnvelopeId { get; set; }
        public Envelope Envelope { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}