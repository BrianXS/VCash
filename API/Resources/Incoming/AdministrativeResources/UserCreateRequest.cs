using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class UserCreateRequest
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Names { get; set; }
        
        [Required]
        public string Surnames { get; set; }
        
        [Required]
        public string PlainPassword { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}