using API.Enums;

namespace API.Resources.Incoming.AdministrativeResources
{
    public class DenominationTypeCreateRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        
        public bool BankNote { get; set; }
        public bool NewSeries { get; set; }

        public int UnitsPerContainer { get; set; }
        public decimal Value { get; set; }
    }
}