using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using CsvHelper;

namespace API.Services.Seeds
{
    public static class BranchSeed
    {
        public static void SeedBranches(IBranchRepository branchRepository)
        {
            if (branchRepository.CountBranches() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/Countries.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<BranchCreateRequest>();
                branchRepository.CreateBranchRange(records.ToList());
            }
        }
    }
}