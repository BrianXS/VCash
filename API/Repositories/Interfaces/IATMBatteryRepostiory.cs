using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IATMBatteryRepostiory
    {
        ATMBatteryResponse FindATMBatteryResponseById(int id);
        ATMBattery FindATMBatteryById(int id);
        List<ATMBatteryResponse> GetAllATMBatteries();
        void CreateATMBattery(ATMBatteryCreateRequest branch);
        ATMBatteryResponse UpdateATMBattery(int id, ATMBatteryUpdateRequest branch);
        void DeleteATMBattery(ATMBattery branch);
    }
}