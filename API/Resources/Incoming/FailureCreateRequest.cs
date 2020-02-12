using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class FailureCreateRequest
    {
        [Required]
        public string Description { get; set; }
        
        [Required]
        public bool ClientFault { get; set; }
    }
}