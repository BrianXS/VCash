using System;
using API.Enums;
using API.Enums.ATM;
using ValueType = API.Enums.ValueType;

namespace API.Resources.Outgoing.OfficeMovementResources
{
    public class OfficeCheckInResponse
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
        
        public decimal DeclaredBankNotes { get; set; }
        public decimal CountedBanknotes { get; set; }
        
        public decimal DeclaredCoins { get; set; }
        public decimal CountedCoins { get; set; }
        
        public decimal DeclaredCash { get; set; }
        public decimal CountedCash { get; set; }
        
        public decimal TotalDifference { get; set; }

        public string DeclaredCashInWords { get; set; }
        public string CountedCashInWords { get; set; }

        public bool Failed { get; set; }
        public bool Custody { get; set; }
        public bool Counted { get; set; }
        
        public int OriginId { get; set; }
        public string Origin { get; set; }

        public int DestinationId { get; set; }
        public string Destination { get; set; }

        public int FailureId { get; set; }
        public string Failure { get; set; }

        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        
        public int MainVehicleId { get; set; }
        public string MainVehicle { get; set; }

        public int SecondaryVehicleId { get; set; }
        public string SecondaryVehicle { get; set; }
    }
}