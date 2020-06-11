using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class CitySeed
    {
        public static void SeedCities(ICityRepository cityRepository)
        {
            if (!cityRepository.GetAllCities().Any())
            {
                using var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Cities.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<CityCreateRequest>();
                cityRepository.CreateCitiesRange(records.ToList());
            }
        }
    }
}