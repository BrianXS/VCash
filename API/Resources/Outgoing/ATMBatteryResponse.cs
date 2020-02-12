using System.Collections.Generic;
using API.Entities;

namespace API.Resources.Outgoing
{
    public class ATMBatteryResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public List<string> Atms { get; set; }
    }
}