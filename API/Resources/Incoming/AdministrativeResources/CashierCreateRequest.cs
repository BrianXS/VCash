using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class CashierCreateRequest
    {
        [Required]
        public string FullName { get; set; }
        
        [Required]
        public PersonalDocumentType DocumentType { get; set; }
        
        [Required]
        public string Document { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}