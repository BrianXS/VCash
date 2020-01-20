namespace API.Resources.Incoming
{
    public class RefreshTokenRequest
    {
        public string OldToken { get; set; }
        public string RefreshToken { get; set; }
    }
}