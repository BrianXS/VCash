using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums.ATM;

namespace API.Resources.Incoming
{
    public class ATMCreateRequest
    {
        [Required]
        public bool LocalizationCode { get; set; }
        
        [Required]
        public bool Emergency { get; set; }

        [Required]
        public decimal MaxValue { get; set; }
        
        [Required]
        public Brand Brand { get; set; }
        
        [Required]
        public Mode Mode { get; set; }

        [Required]
        public DateTime From { get; set; }
        
        [Required]
        public int OfficeId { get; set; }
        
        public int? AtmBatteryId { get; set; }
    }
}