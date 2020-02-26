using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class StateCreateRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int CountryId { get; set; }
    }
}