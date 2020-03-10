using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;
using API.Enums.ATM;
using ValueType = API.Enums.ValueType;

namespace API.Entities
{
    public class Movement
    {
        public int Id { get; set; }

        public string PayrollNumber { get; set; }
        public string ServiceNumber { get; set; }
        public Currency Currency { get; set; }
        public DateTime ServiceDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string GeneralNotification { get; set; }
        
        public ServiceType ServiceType { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
        public MovementType MovementType { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        
        public ValueType ValueType { get; set; }
        public int AmmountOfContainers { get; set; }
        
        public int AmmountOfBanknoteKits { get; set; }
        public int AmmountOfCoinKits { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredBankNotes { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CountedBanknotes { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredCoins { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CountedCoins { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeclaredCash { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CountedCash { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalDifference { get; set; }

        public string DeclaredCashInWords { get; set; }
        public string CountedCashInWords { get; set; }

        public bool Failed { get; set; }
        public bool Custody { get; set; }
        public bool OfficeToOffice { get; set; }
        
        public int OriginId { get; set; }
        public Office Origin { get; set; }

        public int DestinationId { get; set; }
        public Office Destination { get; set; }

        public int FailureId { get; set; }
        public Failure Failure { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        
        public int MainVehicleId { get; set; }
        public Vehicle MainVehicle { get; set; }

        public int SecondaryVehicleId { get; set; }
        public Vehicle SecondaryVehicle { get; set; }

        public List<Envelope> Envelopes { get; set; }
        public List<Cheque> Cheques { get; set; }
        public List<Bag> Bags { get; set; }

        public bool Active { get; set; }
    }
}