using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class EmployeeSeed
    {
        public static void SeedEmployees(IEmployeeRepository employeeRepository)
        {
            if (!employeeRepository.GetAllEmployees().Any())
            {
                using var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Employees.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<EmployeeCreateRequest>();
                employeeRepository.CreateEmployeeRange(records.ToList());
            }
        }
    }
}