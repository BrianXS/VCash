using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds
{
    public static class CountrySeed
    {
        public static void SeedCountries(ICountryRepository countryRepository)
        {
            if (countryRepository.CountCountries() == 0)
            {
                using var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Countries.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<CountryCreateRequest>();
                countryRepository.CreateMultipleCountries(records.ToList());   
            }
        }
    }
}