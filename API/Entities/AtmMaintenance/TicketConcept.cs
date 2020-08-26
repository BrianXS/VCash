using API.Enums.ATM;

namespace API.Entities.AtmMaintenance
{
    public class TicketConcept
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Brand Platform { get; set; }
    }
}