using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities
{
    public class Envelope
    {
        public int Id { get; set; }

        public string EnvelopeSerial { get; set; }
        public string BagSerial { get; set; }
        public string SealSerial { get; set; }
        public string ClientSerial { get; set; }

        public DateTime ArrivalDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredCash { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CountedCash { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredDocumentValue { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CountedDocumentValue { get; set; }

        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }

        public int MovementId { get; set; }
        public Movement Movement { get; set; }
        
        public List<EnvelopeDenomination> Denominations { get; set; }
        public List<EnvelopeNotification> Notifications { get; set; }
    }
}