using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class ATMBatteryUpdateRequest
    {
        [Required]
        public string Code { get; set; }
    }
}