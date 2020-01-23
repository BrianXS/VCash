using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        
        public string Code { get; set; }
        public string GpsCode { get; set; }
        public bool Active { get; set; }

        public BusinessUnit BusinessUnit { get; set; }
        public VehicleType VehicleType { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal AllowedAmmount { get; set; }
        
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}