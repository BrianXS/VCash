using System.Globalization;
using System.IO;
using System.Linq;
using API.Entities.AtmMaintenance;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class Vehicles
    {
        public static void SeedVehicles(IVehicleRepository vehicleRepository)
        {
            if (!vehicleRepository.GetAllVehicles().Any())
            {
                using var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Vehicles.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<VehicleCreateRequest>();
                vehicleRepository.CreateVehicleRange(records.ToList());
            }
        }
    }
}