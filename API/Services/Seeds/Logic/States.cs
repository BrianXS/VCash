using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class States
    {
        public static void SeedStates(IStateRepository stateRepository)
        {
            if (stateRepository.CountStates() == 0)
            {
                using var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/States.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
                
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<StateCreateRequest>();
                stateRepository.CreateStateRange(records.ToList());   
            }
        }
    }
}