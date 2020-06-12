using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class Customers
    {
        public static void SeedCustomers(ICustomerRepository customerRepository)
        {
            if (customerRepository.CountCusdtomers() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Customers.csv");
                using var csv = new CsvReader(stream, new CultureInfo("en-US", false));
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<CustomerCreateRequest>();
                customerRepository.CreateCustomerRange(records.ToList());
            }
        }
    }
}