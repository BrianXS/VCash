using System.Collections.Generic;
using API.Entities;
using API.Enums;

namespace API.Resources.Outgoing
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }

        public CorporateDocumentType DocumentType { get; set; }
        public string Document { get; set; }
        
        public int HeadquartersId { get; set; }
        public string Headquarters { get; set; }
        
        public int InvoicingCityId { get; set; }
        public string InvoicingCity { get; set; }
        
        public string FirstKeyPerson { get; set; }
        public string FirstKeyPersonTitle { get; set; }

        public string SecondKeyPerson { get; set; }
        public string SecondKeyPersonTitle { get; set; }

        public bool SubClient { get; set; }
        public int ParentClient { get; set; }

        public List<string> Offices { get; set; }
        public List<string> Cashiers { get; set; }
    }
}