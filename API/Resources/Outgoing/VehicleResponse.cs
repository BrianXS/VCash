using API.Enums;

namespace API.Resources.Outgoing
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        
        public int BranchId { get; set; }
        public string Branch { get; set; }

        public string Code { get; set; }
        public string GpsCode { get; set; }
        
        public BusinessUnit BusinessUnit { get; set; }
        public VehicleType VehicleType { get; set; }
        
        public decimal AllowedAmmount { get; set; }
    }
}