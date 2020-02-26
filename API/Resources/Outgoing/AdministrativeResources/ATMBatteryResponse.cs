using System.Collections.Generic;

namespace API.Resources.Outgoing.AdministrativeResources
{
    public class ATMBatteryResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public List<string> Atms { get; set; }
    }
}