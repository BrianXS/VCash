using System;
using API.Enums;

namespace API.Resources.Incoming.OfficeMovementResources.CountingProcessDtos
{
    public class ChequeDto
    {
        public string ChequeSerial { get; set; }
        public string BagSerial { get; set; }
        public string SealSerial { get; set; }
        
        public decimal DeclaredDocumentValue { get; set; }
        public Bank Bank { get; set; }
        
        public DateTime ArrivalDate { get; set; }
    }
}