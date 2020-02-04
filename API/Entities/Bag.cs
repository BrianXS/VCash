using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities
{
    public class Bag
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
        public Movement Movement { get; set; }
        
        public List<BagDenomination> Denominations { get; set; }
        public List<BagNotification> Notifications { get; set; }
    }
}