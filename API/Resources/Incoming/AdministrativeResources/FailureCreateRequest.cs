using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class FailureCreateRequest
    {
        [Required]
        public string Description { get; set; }
        
        [Required]
        public bool ClientFault { get; set; }
    }
}