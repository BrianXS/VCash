using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class CustomerFundCreateRequest
    {
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int OfficeId { get; set; }
    }
}