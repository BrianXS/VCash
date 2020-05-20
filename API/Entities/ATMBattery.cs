using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class ATMBattery : IAuditable
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public List<ATM> Atms { get; set; }
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}