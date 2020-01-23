namespace API.Entities
{
    public class ATM
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}