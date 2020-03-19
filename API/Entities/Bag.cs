using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities
{
    public class Bag : IAuditable
    {
        public int Id { get; set; }
        
        public string BagSerial { get; set; }
        public string SealSerial { get; set; }
        public DateTime ArrivalDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredCash { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CountedCash { get; set; }

        public int MovementId { get; set; }
        public OfficeMovement OfficeMovement { get; set; }
        
        public List<BagDenomination> Denominations { get; set; }
        public List<BagNotification> Notifications { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}