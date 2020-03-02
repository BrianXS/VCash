using System.ComponentModel.DataAnnotations;
using System.Linq;
using API.Resources.Incoming.OfficeMovementResources;
using Microsoft.EntityFrameworkCore.Internal;

namespace API.Utils.ResourceAnnotations
{
    public class CountingProcessVerification : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var counter = 0;
            var movimiento = (CountingProcessRequest) validationContext.ObjectInstance;

            if (movimiento.Bags.Any())
                counter++;
            
            if (movimiento.Cheques.Any())
                counter++;

            if (movimiento.Envelopes.Any())
                counter++;
            
            if (counter.Equals(0))
                return new ValidationResult("No containers were found");
            
            return base.IsValid(value, validationContext);
        }
    }
}