using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums.ATM;

namespace API.Entities
{
    public class ATM
    {
        public int Id { get; set; }
        
        public bool LocalizationCode { get; set; }
        public bool Emergency { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal MaxValue { get; set; }
        public Brand Brand { get; set; }
        public Mode Mode { get; set; }

        public DateTime From { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
        
        public int AtmBatteryId { get; set; }
        public AtmBattery AtmBattery { get; set; }
    }
}