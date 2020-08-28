using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities.Administrative
{
    public class Office : IAuditable
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string VatcoCode { get; set; }
        public string ClientCode { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Coverage Coverage { get; set; }

        public string Manager { get; set; }
        public string ManagerDetails { get; set; }
        public string ManagerEmail { get; set; }

        public OfficeType OfficeType { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Lng { get; set; }

        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        
        public bool HasKits { get; set; }
        public bool HasKeys { get; set; }
        public bool HasEnvelopes { get; set; }
        public bool HasCheques { get; set; }
        public bool HasDocuments { get; set; }
        public bool IsFund { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }

        public CustomerFund CustomerFunds { get; set; }
        
        public bool Active { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}