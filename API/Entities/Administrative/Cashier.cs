using System;
using API.Enums;

namespace API.Entities.Administrative
{
    public class Cashier : IAuditable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public PersonalDocumentType DocumentType { get; set; }
        public string Document { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}