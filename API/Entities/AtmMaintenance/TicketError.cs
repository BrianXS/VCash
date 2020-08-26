using API.Enums;

namespace API.Entities.AtmMaintenance
{
    public class TicketError
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public TicketErrorType ErrorType { get; set; }
        public TicketPlatform Platform { get; set; }
    }
}