using API.Enums;

namespace API.Entities
{
    public class Cashier
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public PersonalDocumentType DocumentType { get; set; }
        public string Document { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}