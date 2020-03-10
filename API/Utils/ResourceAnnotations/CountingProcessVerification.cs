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
            var movement = (CountingProcessRequest) validationContext.ObjectInstance;

            if (movement.Bags.Any())
            {
                var bagDuplicates = movement.Bags.GroupBy(b => b.BagSerial)
                    .Where(b => b.Skip(1).Any()).SelectMany(b => b);
                
                if(bagDuplicates.Any())
                    return new ValidationResult("Bag Serials must be unique");

                var denomDuplicates = movement.Bags
                    .SelectMany(b => b.Denominations)
                    .GroupBy(d => d.DenominationTypeId)
                    .Where(id => id.Skip(1).Any())
                    .SelectMany(id => id);
                
                if(denomDuplicates.Any())
                    return new ValidationResult("Denominations must be unique");

                var notificationDuplicates = movement.Bags
                    .SelectMany(b => b.Notifications)
                    .GroupBy(n => new {n.DenominationTypeId, n.NotificationTypeId})
                    .Where(id => id.Skip(1).Any())
                    .SelectMany(id => id);
                
                if(notificationDuplicates.Any())
                    return new ValidationResult("Notifications must be unique");

                
                counter++;   
            }

            if (movement.Cheques.Any())
            {
                var chequeDuplicates = movement.Cheques.GroupBy(x => x.ChequeSerial)
                    .Where(x => x.Skip(1).Any()).SelectMany(x => x);
                
                if(chequeDuplicates.Any())
                    return new ValidationResult("Cheque Serials must be unique");

                counter++;
            }

            if (movement.Envelopes.Any())
            {
                var envelopeDuplicates = movement.Envelopes.GroupBy(x => x.EnvelopeSerial)
                    .Where(x => x.Skip(1).Any()).SelectMany(x => x);
                
                if(envelopeDuplicates.Any())
                    return new ValidationResult("Envelope Serials must be unique");
                
                var denomDuplicates = movement.Envelopes
                    .SelectMany(b => b.Denominations)
                    .GroupBy(d => d.DenominationTypeId)
                    .Where(id => id.Skip(1).Any())
                    .SelectMany(id => id);
                
                if(denomDuplicates.Any())
                    return new ValidationResult("Denominations must be unique");
                
                var notificationDuplicates = movement.Envelopes
                    .SelectMany(b => b.Notifications)
                    .GroupBy(n => n.DenominationTypeId)
                    .Where(id => id.Skip(1).Any())
                    .SelectMany(id => id);
                
                if(notificationDuplicates.Any())
                    return new ValidationResult("Notifications must be unique");
                
                counter++;
            }
            
            if (!counter.Equals(1))
                return new ValidationResult("Invalid Request");
            
            return base.IsValid(value, validationContext);
        }
    }
}