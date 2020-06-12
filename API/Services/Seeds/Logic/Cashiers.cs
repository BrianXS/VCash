using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class Cashiers
    {
        public static void SeedCashiers(ICashierRepository cashierRepository)
        {
            if (cashierRepository.CountCashiers() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Cashiers.csv");
                using var csv = new CsvReader(stream, new CultureInfo("en-US", false));
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<CashierCreateRequest>();
                cashierRepository.CreateCashiersRange(records.ToList());
            }
        }
    }
}