using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Incoming.AtmMaintenanceResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class AtmModules
    {
        public static void SeedAtmModules(IAtmModuleRepository atmModuleRepository)
        {
            if (atmModuleRepository.Count() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/AtmModules.csv");
                using var csv = new CsvReader(stream, new CultureInfo("en-US", false));
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<AtmModuleRequest>();
                atmModuleRepository.CreateAtmModulesRange(records.ToList());
            }
        }
    }
}