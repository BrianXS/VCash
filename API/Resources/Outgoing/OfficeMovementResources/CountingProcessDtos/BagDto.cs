using System;
using System.Collections.Generic;

namespace API.Resources.Outgoing.OfficeMovementResources.CountingProcessDtos
{
    public class BagDto
    {
        public string BagSerial { get; set; }
        public string SealSerial { get; set; }
        public DateTime ArrivalDate { get; set; }

        public decimal DeclaredCash { get; set; }
        public decimal CountedCash { get; set; }

        public List<BagDenominationDto> Denominations { get; set; }
        public List<BagNotificationDto> Notifications { get; set; }
    }
}