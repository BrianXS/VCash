using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;
using API.Enums;

namespace API.Resources.Outgoing
{
    public class OfficeResponse
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public string Customer { get; set; }

        public string VatcoCode { get; set; }
        public string ClientCode { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Prefix { get; set; }
        public Coverage Coverage { get; set; }

        public string Manager { get; set; }
        public string ManagerDetails { get; set; }
        public string ManagerEmail { get; set; }

        public OfficeType OfficeType { get; set; }
        
        public decimal Lat { get; set; }
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
        public string City { get; set; }

        public int? BusinessTypeId { get; set; }
        public string BusinessType { get; set; }

        public bool Active { get; set; }
    }
}