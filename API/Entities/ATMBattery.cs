using System.Collections.Generic;

namespace API.Entities
{
    public class AtmBattery
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public List<ATM> Atms { get; set; }
    }
}