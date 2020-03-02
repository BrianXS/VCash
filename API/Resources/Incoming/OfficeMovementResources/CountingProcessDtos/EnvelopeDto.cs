using System;
using System.Collections.Generic;

namespace API.Resources.Incoming.OfficeMovementResources.CountingProcessDtos
{
    public class EnvelopeDto
    {
        public string EnvelopeSerial { get; set; }
        public string BagSerial { get; set; }
        public string SealSerial { get; set; }
        public string ClientSerial { get; set; }
        public DateTime ArrivalDate { get; set; }
        
        public decimal DeclaredCash { get; set; }
        public decimal DeclaredDocumentValue { get; set; }

        public int CashierId { get; set; }

        public List<EnvelopeDenominationDto> Denominations { get; set; }
        public List<EnvelopeNotificationDto> Notifications { get; set; }
    }
}