using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;
using API.Enums;

namespace API.Resources.Incoming
{
    
    public class VehicleCreateRequest
    {
        [Required]
        public string Model { get; set; }
        
        [Required]
        public string Plate { get; set; }
        
        [Required]
        public string Color { get; set; }

        [Required]
        public string Code { get; set; }
        
        [Required]
        public string GpsCode { get; set; }
        
        [Required]
        public BusinessUnit BusinessUnit { get; set; }
        
        [Required]
        public VehicleType VehicleType { get; set; }
        
        [Required]
        public decimal AllowedAmmount { get; set; }
        
        [Required]
        public int BranchId { get; set; }
    }
}