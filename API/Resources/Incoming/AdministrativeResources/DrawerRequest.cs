using System.ComponentModel.DataAnnotations;
using API.Entities;
using API.Enums;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class DrawerRequest
    {
        [Required]
        public decimal MaxValue { get; set; }
        
        [Required]
        public int DefaultQuantity { get; set; }
        
        [Required]
        public DrawerType DrawerType { get; set; }
        
        [Required]
        public DrawerFunction DrawerFunction { get; set; }

        [Required]
        public int DrawerRangeId { get; set; }
        
        [Required]
        public int DenominationTypeId { get; set; }
    }
}