using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class ATMBatteryCreateRequest
    {
        [Required]
        public string Code { get; set; }
    }
}