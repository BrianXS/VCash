using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IAtmBatteryRepostiory
    {
        ATMBatteryResponse FindATMBatteryResponseById(int id);
        ATMBattery FindATMBatteryById(int id);
        List<ATMBatteryResponse> GetAllATMBatteries();
        void CreateATMBattery(ATMBatteryCreateRequest battery);
        void CreateATMBatteryRange(List<ATMBatteryCreateRequest> battery);
        ATMBatteryResponse UpdateATMBattery(int id, ATMBatteryUpdateRequest battery);
        void DeleteATMBattery(ATMBattery battery);
        int CountBatteries();
    }
}