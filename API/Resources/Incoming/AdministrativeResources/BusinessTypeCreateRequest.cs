using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class BusinessTypeCreateRequest
    {
        [Required]
        public int Code { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}