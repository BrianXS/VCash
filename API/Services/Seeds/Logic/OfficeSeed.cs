using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class OfficeSeed
    {
        public static void SeedOffices(IOfficeRepository officeRepository)
        {
            if (officeRepository.CountOffices() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Offices.csv");
                using var csv = new CsvReader(stream, new CultureInfo("en-US", false));
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<OfficeCreateRequest>();
                officeRepository.CreateOfficesRange(records.ToList());
            }
        }
    }
}