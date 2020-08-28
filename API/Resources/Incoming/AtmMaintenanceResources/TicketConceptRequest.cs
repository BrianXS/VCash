using API.Enums.ATM;

namespace API.Resources.Incoming.AtmMaintenanceResources
{
    public class TicketConceptRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Brand Platform { get; set; }
    }
}