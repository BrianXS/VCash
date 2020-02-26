namespace API.Resources.Outgoing.AdministrativeResources
{
    public class CustomerFundResponse
    {
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        
        public int OfficeId { get; set; }
        public string Office { get; set; }
    }
}