using API.Enums.ATM;

namespace API.Resources.Outgoing.AtmMaintenanceResources
{
    public class TicketStatusResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Brand Platform { get; set; }
    }
}