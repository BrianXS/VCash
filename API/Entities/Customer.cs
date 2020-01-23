using System.Collections.Generic;
using API.Enums;

namespace API.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }

        public CorporateDocumentType DocumentType { get; set; }
        public string Document { get; set; }

        public int? HeadquartersId { get; set; }
        public City Headquarters { get; set; }
        
        public int? InvoicingCityId { get; set; }
        public City InvoicingCity { get; set; }
        
        public string FirstKeyPerson { get; set; }
        public string FirstKeyPersonTitle { get; set; }

        public string SecondKeyPerson { get; set; }
        public string SecondKeyPersonTitle { get; set; }

        public bool SubClient { get; set; }
        public int ParentClient { get; set; }
        
        public string Address { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

        public List<Location> Locations { get; set; }
        public List<Cashier> Cashiers { get; set; }
    }
}