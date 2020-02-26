using API.Enums;

namespace API.Resources.Outgoing.AdministrativeResources
{
    public class CashierResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public PersonalDocumentType DocumentType { get; set; }
        public string Document { get; set; }
        
        public int CustomerId { get; set; }
        public string Customer { get; set; }
    }
}