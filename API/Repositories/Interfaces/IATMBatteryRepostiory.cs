using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IATMBatteryRepostiory
    {
        ATMBatteryResponse FindATMBatteryResponseById(int id);
        ATMBattery FindATMBatteryById(int id);
        List<ATMBatteryResponse> GetAllATMBatteries();
        void CreateATMBattery(ATMBatteryCreateRequest battery);
        ATMBatteryResponse UpdateATMBattery(int id, ATMBatteryUpdateRequest battery);
        void DeleteATMBattery(ATMBattery battery);
    }
}