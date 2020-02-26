using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class StateUpdateRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int CountryId { get; set; }
    }
}