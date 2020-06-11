using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class BranchUpdateRequest
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