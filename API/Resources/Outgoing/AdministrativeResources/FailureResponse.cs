namespace API.Resources.Outgoing.AdministrativeResources
{
    public class FailureResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool ClientFault { get; set; }
    }
}