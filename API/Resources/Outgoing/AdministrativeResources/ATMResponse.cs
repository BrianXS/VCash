using System;
using API.Enums.ATM;

namespace API.Resources.Outgoing.AdministrativeResources
{
    public class ATMResponse
    {
        public int Id { get; set; }
        
        public bool LocalizationCode { get; set; }
        public bool Emergency { get; set; }
        public decimal MaxValue { get; set; }
        public Brand Brand { get; set; }
        public Mode Mode { get; set; }

        public DateTime From { get; set; }

        public int OfficeId { get; set; }
        public string Office { get; set; }
        
        public int? AtmBatteryId { get; set; }
        public string AtmBattery { get; set; }
        
        public int DrawerRangeId { get; set; }
        public string DrawerRange { get; set; }
    }
}