using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class FailureUpdateRequest
    {
        [Required]
        public string Description { get; set; }
        
        [Required]
        public bool ClientFault { get; set; }
    }
}