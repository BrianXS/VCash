namespace API.Resources.Outgoing.AdministrativeResources
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ExpirationDate { get; set; }
    }
}