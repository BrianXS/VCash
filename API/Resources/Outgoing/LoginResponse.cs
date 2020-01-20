namespace API.Resources.Outgoing
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ExpirationDate { get; set; }
    }
}