using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class CountryCreateRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Code { get; set; }
    }
}