using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class CityCreateRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int StateId { get; set; }
        
        [Required]
        public int BranchId { get; set; }
    }
}