namespace API.Resources.Incoming.AdministrativeResources
{
    public class RefreshTokenRequest
    {
        public string OldToken { get; set; }
        public string RefreshToken { get; set; }
    }
}