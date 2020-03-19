using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities
{
    public class Cheque : IAuditable
    {
        public int Id { get; set; }

        public string ChequeSerial { get; set; }
        public string BagSerial { get; set; }
        public string SealSerial { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredDocumentValue { get; set; }
        public Bank Bank { get; set; }
        
        public DateTime ArrivalDate { get; set; }
        
        public int MovementId { get; set; }
        public OfficeMovement OfficeMovement { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}