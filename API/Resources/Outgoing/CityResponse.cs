namespace API.Resources.Outgoing
{
    public class CityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int StateId { get; set; }
        public string State { get; set; }
        
        public int BranchId { get; set; }
        public string Branch { get; set; }
        
        public string Country { get; set; }
    }
}