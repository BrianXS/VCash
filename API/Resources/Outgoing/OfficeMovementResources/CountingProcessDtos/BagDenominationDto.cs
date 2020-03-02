using API.Entities;

namespace API.Resources.Outgoing.OfficeMovementResources.CountingProcessDtos
{
    public class BagDenominationDto
    {
        public int Quantity { get; set; }
        public int Bundle { get; set; }
        public int Singles { get; set; }
        public decimal TotalCountedCash { get; set; }
        public DenominationType DenominationType { get; set; }
    }
}