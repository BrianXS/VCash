using API.Entities;

namespace API.Resources.Incoming.OfficeMovementResources.CountingProcessDtos
{
    public class BagDenominationDto
    {
        public int Quantity { get; set; }
        public int DenominationTypeId { get; set; }
    }
}