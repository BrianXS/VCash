using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class Batteries
    {
        public static void SeedBatteries(IATMBatteryRepostiory batteryRepostiory)
        {
            if (batteryRepostiory.CountBatteries() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Batteries.csv");
                using var csv = new CsvReader(stream, new CultureInfo("en-US", false));
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<ATMBatteryCreateRequest>();
                batteryRepostiory.CreateATMBatteryRange(records.ToList());
            }
        }
    }
}