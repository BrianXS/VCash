using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;
using API.Enums;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class DrawerRangeRequest
    {
        [Required]
        public string Code { get; set; }
        
        [Required]
        public Currency Currency { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
    }
}