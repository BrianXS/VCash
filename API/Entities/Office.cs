namespace API.Entities
{
    public class Office
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}