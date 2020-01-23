using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities
{
    public class Location
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string InternalCode { get; set; }
        public string ExternalCode { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Prefix { get; set; }
        public Coverage Coverage { get; set; }

        public string Manager { get; set; }
        public string ManagerDetails { get; set; }
        public string ManagerEmail { get; set; }

        public LocationType LocationType { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Lng { get; set; }

        public DateTime From { get; set; }
        public DateTime Until { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        
        public bool Active { get; set; }
    }
}