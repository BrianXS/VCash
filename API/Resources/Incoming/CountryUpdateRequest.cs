using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class CountryUpdateRequest
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Code { get; set; }
    }
}