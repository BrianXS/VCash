using System.Collections.Generic;
using API.Enums;
using API.Resources.Incoming.OfficeMovementResources.CountingProcessDtos;
using API.Utils.ResourceAnnotations;

namespace API.Resources.Incoming.OfficeMovementResources
{
    [CountingProcessVerification]
    public class CountingProcessRequest
    {
        public ValueType ValueType { get; set; }
        public List<BagDto> Bags { get; set; }
        public List<ChequeDto> Cheques { get; set; }
        public List<EnvelopeDto> Envelopes { get; set; }
    }
}