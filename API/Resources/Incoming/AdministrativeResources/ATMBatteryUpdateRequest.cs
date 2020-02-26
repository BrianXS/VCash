using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class ATMBatteryUpdateRequest
    {
        [Required]
        public string Code { get; set; }
    }
}