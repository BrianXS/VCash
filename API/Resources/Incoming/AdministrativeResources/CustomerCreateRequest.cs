using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class CustomerCreateRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string CorporateName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Website { get; set; }
        
        [Required]
        public string Phone { get; set; }

        [Required]
        public CorporateDocumentType DocumentType { get; set; }
        
        [Required]
        public string Document { get; set; }

        [Required]
        public int HeadquartersId { get; set; }
        
        [Required]
        public int InvoicingCityId { get; set; }

        [Required]
        public string FirstKeyPerson { get; set; }
        
        [Required]
        public string FirstKeyPersonTitle { get; set; }

        [Required]
        public string SecondKeyPerson { get; set; }
        
        [Required]
        public string SecondKeyPersonTitle { get; set; }
        
        public bool SubClient { get; set; }
        public int ParentClient { get; set; }
    }
}