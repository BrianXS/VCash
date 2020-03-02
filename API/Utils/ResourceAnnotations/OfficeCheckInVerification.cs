using System.ComponentModel.DataAnnotations;
using API.Resources.Incoming.OfficeMovementResources;

namespace API.Utils.ResourceAnnotations
{
    public class OfficeCheckInVerification : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movement = (OfficeCheckInRequest) validationContext.ObjectInstance;
            
            if (movement.MainVehicleId.Equals(movement.SecondaryVehicleId))
                return new ValidationResult("Vehicles can't be the same");
            
            if (movement.OriginId.Equals(movement.DestinationId))
                return new ValidationResult("Origin Can't Be The Same as Destination");
            
            if (!movement.EndTime.CompareTo(movement.StartTime).Equals(1))
                return new ValidationResult("Ending time must be greater than starting time");

            return base.IsValid(value, validationContext);
        }
    }
}