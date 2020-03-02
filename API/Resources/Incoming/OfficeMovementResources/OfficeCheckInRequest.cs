using System;
using System.ComponentModel.DataAnnotations;
using API.Enums;
using API.Enums.ATM;
using API.Utils.ResourceAnnotations;
using ValueType = API.Enums.ValueType;

namespace API.Resources.Incoming.OfficeMovementResources
{
    [OfficeCheckInVerification]
    public class OfficeCheckInRequest
    {
        [Required]
        public string PayrollNumber { get; set; }
        
        [Required]
        public string ServiceNumber { get; set; }
        
        [Required]
        public Currency Currency { get; set; }
        
        [Required]
        public DateTime ServiceDate { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public ServiceType ServiceType { get; set; }
        
        [Required]
        public MovementType MovementType { get; set; }
        
        [Required]
        public BusinessUnit BusinessUnit { get; set; }
        
        [Required]
        public ValueType ValueType { get; set; }
        
        [Required]
        public int AmmountOfContainers { get; set; }
        
        [Required]
        public decimal DeclaredBankNotes { get; set; }

        [Required]
        public decimal DeclaredCoins { get; set; }

        [Required]
        public decimal DeclaredCash { get; set; }

        public bool Failed { get; set; }
        public bool Custody { get; set; }
        public bool OfficeToOffice { get; set; }
        public bool Counted { get; set; }
        public int FailureId { get; set; }
        
        [Required]
        public int OriginId { get; set; }
        
        [Required]
        public int DestinationId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int MainVehicleId { get; set; }
        public int SecondaryVehicleId { get; set; }
        
        public string GeneralNotification { get; set; }
    }
}