using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class ATMBatteryCreateRequest
    {
        [Required]
        public string Code { get; set; }
    }
}