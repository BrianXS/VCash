namespace API.Entities
{
    public class Failure
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool ClientFault { get; set; }
    }
}