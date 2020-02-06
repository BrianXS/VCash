using System.ComponentModel.DataAnnotations;

namespace API.Resources.Incoming
{
    public class UpdateUserRequest
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string PlainPassword { get; set; }
        public string Email { get; set; }
    }
}