using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class BranchCreateRequest
    {
        [Required]
        public int Code { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Lat { get; set; }
        
        [Required]
        public double Lng { get; set; }
    }
}