using System;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Resources.Incoming
{
    public class OfficeCreateRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string VatcoCode { get; set; }
        
        [Required]
        public string ClientCode { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public Coverage Coverage { get; set; }

        [Required]
        public OfficeType OfficeType { get; set; }

        [Required]
        public decimal Lat { get; set; }
        
        [Required]
        public decimal Lng { get; set; }

        [Required]
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        
        [Required]
        public bool HasKits { get; set; }
        
        [Required]
        public bool HasKeys { get; set; }
        
        [Required]
        public bool HasEnvelopes { get; set; }
        
        [Required]
        public bool HasCheques { get; set; }
        
        [Required]
        public bool HasDocuments { get; set; }
        
        [Required]
        public bool IsFund { get; set; }

        [Required]
        public int CityId { get; set; }
        
        public string Manager { get; set; }
        public string ManagerDetails { get; set; }
        public string ManagerEmail { get; set; }
        public string Prefix { get; set; }
        public int? BusinessTypeId { get; set; }
    }
}