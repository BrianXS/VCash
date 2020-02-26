using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class CustomerFundUpdateRequest
    {
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int OfficeId { get; set; }
    }
}