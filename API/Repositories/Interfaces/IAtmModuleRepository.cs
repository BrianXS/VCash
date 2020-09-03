using System.Collections.Generic;
using API.Entities;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Resources.Outgoing.AtmMaintenanceResources;
using API.Services.Seeds.Logic;

namespace API.Repositories.Interfaces
{
    public interface IAtmModuleRepository
    {
        AtmModuleResponse FindAtmModuleResponseById(int id);
        AtmModule FindAtmModuleById(int id);
        AtmModule FindAtmModuleByDescriptionAndPlatform(string name, Brand platform);
        List<AtmModuleResponse> GetAllAtmModules();
        void CreateAtmModule(AtmModuleRequest atmModule);
        void CreateAtmModulesRange(List<AtmModuleRequest> atmModules);
        AtmModuleResponse UpdateAtmModule(int id, AtmModuleRequest updatedAtmModule);
        void DeleteAtmModule(AtmModule atmModule);
        int Count();
    }
}