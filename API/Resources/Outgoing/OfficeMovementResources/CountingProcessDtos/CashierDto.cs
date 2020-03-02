using API.Enums;

namespace API.Resources.Outgoing.OfficeMovementResources.CountingProcessDtos
{
    public class CashierDto
    {
        public string FullName { get; set; }
        public PersonalDocumentType DocumentType { get; set; }
        public string Document { get; set; }
        public string Customer { get; set; }
    }
}